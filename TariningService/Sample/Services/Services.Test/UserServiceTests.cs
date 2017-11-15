using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System;
using Moq;
using Services.Common;
using Services.DataAccess;

namespace Services.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        private User _user;
        private Mock<IUserRepository> _repositoryMoq;

        [TestInitialize]
        public void Initialize() //---- moq initializer.
        {
            _user = new User
            {
                Login = "Hacker",
                Email = "mymailbox@gmail.ru",
                Password = "123"
            };

            _repositoryMoq = new Mock<IUserRepository>();

            //---- setup changing ID in _repositoryMoq.Create() method.
            _repositoryMoq.Setup(r => r.Create(It.IsAny<User>()))
                .Callback<User>(u => u.Id += 10);   

            //---- setup result of _repositoryMoq.LoginUser() call.
            _repositoryMoq.Setup(r => r.LoginUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);    

            //---- setup result of _repositoryMoq.CheckUserByEmail() call.
            _repositoryMoq.Setup(r => r.CheckUserByEmail(It.IsAny<string>()))
                .Returns(true);    

            //---- setup result of _repositoryMoq.Get() call.
            _repositoryMoq.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(_user);    

            //---- setup result of _repositoryMoq.GetUserByLogin() call.
            _repositoryMoq.Setup(r => r.GetUserByLogin(It.IsAny<string>()))
                .Returns(_user);    

            //---- setup changing user as null in _repositoryMoq.Delete() method.
            _repositoryMoq.Setup(r => r.Delete(It.IsAny<int>()))
                 .Callback(() => _user = null);    
        }

        //---- registration tests
        [TestMethod()]
        public void RegisterTestWithCorrectInput()
        {
                //---- setup result of _repositoryMoq.CheckUserByEmail() call.
                _repositoryMoq.Setup(r => r.CheckUserByEmail(It.IsAny<string>()))
                    .Returns(false);

                //---- setup result of _repositoryMoq.GetUserByLogin() call.
                _repositoryMoq.Setup(r => r.GetUserByLogin(It.IsAny<string>()))
                    .Returns((User)null);

            var service = new UserService(_repositoryMoq.Object);
            service.Register(_user);

            Assert.AreNotEqual(default(int), _user.Id); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.Create(It.IsAny<User>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTestWithArgumentNullExceptionInput()
        {
            var service = new UserService(_repositoryMoq.Object);
            service.Register(null);

        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTestWithValidationExceptionIfUserIsExist()
        {
            var service = new UserService(_repositoryMoq.Object);
            service.Register(_user);

        }


        //---- Login tests
        [TestMethod()]
        public void LoginTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            var result = service.Login(_user.Login, _user.Password);

            Assert.AreNotEqual(false, result); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.LoginUser(It.IsAny<string>(), It.IsAny<string>()), () => Times.Once());  //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoginTestIsNullOrEmptyLogin()
        {
            var service = new UserService(_repositoryMoq.Object);
            var result = service.Login("", _user.Password);
            
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoginTestIsNullOrEmptyPassword()
        {
            var service = new UserService(_repositoryMoq.Object);
            var result = service.Login(_user.Login,"");

            Assert.AreNotEqual(false, result); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.LoginUser(It.IsAny<string>(), It.IsAny<string>()), () => Times.Once());  //---- as Moq test
        }


        //---- CheckUserByEmail tests
        [TestMethod()]
        public void CheckUserByEmailTest()
        {
            string email = "mymailbox@gmail.ru";
            var service = new UserService(_repositoryMoq.Object);
            var result = service.CheckUserByEmail(email);

            Assert.AreEqual(true, result); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.CheckUserByEmail(It.IsAny<string>()), () => Times.AtLeastOnce());  //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckUserByEmailTestArgumentNullExceptionEmail()
        {
            string email = "";
            var service = new UserService(_repositoryMoq.Object);
            var result = service.CheckUserByEmail(email);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckUserByEmailTestArgumentExceptionIncorrectEmail()
        {
            var service = new UserService(_repositoryMoq.Object);
            var result = service.CheckUserByEmail("mymailboxgmail.ru");

        }


        //---- GetUser by id tests
        [TestMethod()]
        public void GetUserTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            var resultUser = service.GetUser(_user.Id);

            Assert.AreEqual(_user.Id, resultUser.Id); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.Get(It.IsAny<int>()), () => Times.Exactly(1));  //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserTestArgumentNullException()
        {
            //---- setup result of _repositoryMoq.Get() call.
            _repositoryMoq.Setup(r => r.Get(It.IsAny<int>()))
                .Returns((User)null);

            var service = new UserService(_repositoryMoq.Object);
            var resultUser = service.GetUser(_user.Id);

        }


        //---- GetUserByLogin tests
        [TestMethod()]
        public void GetUserByLoginTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            var result = service.GetUserByLogin(_user.Login);

            Assert.AreEqual(_user.Login, result.Login); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.GetUserByLogin(It.IsAny<string>()), () => Times.Exactly(1));  //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserByLoginTestArgumentNullException()
        {
            var service = new UserService(_repositoryMoq.Object);
            var result = service.GetUserByLogin("");

        }


        //---- Unregister tests
        [TestMethod()]
        public void UnregisterTest()
        {
            var service = new UserService(_repositoryMoq.Object);
            service.Unregister(_user.Id);

            Assert.AreEqual(null, _user); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.Delete(It.IsAny<int>()), () => Times.Exactly(1));  //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnregisterTestArgumentNullException()
        {
            //---- setup result of _repositoryMoq.Get() call.
            _repositoryMoq.Setup(r => r.Get(It.IsAny<int>()))
                .Returns((User)null);

            var service = new UserService(_repositoryMoq.Object);
            service.Unregister(_user.Id);

        }


    }
}