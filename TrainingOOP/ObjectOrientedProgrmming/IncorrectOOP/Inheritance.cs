using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncorrectOOPv1.Interface;

namespace IncorrectOOPv1
{
    /// <summary>
    /// Базовый класс мебель
    /// </summary>
    public class Furniture : IDeconstruct<Furniture>
    {
        private string _name;
        private string _material;
        private DateTime _age;

        public string Name { get => _name; }
        public string Material { get => _material; }
        public DateTime Age { get => _age; }

        public Furniture()
        {
            this._name = "Furniture";
            this._material = "Wood";
            this._age = DateTime.UtcNow;
        }
        public Furniture(string name, string material) : this()
        {
            this._name = name;
            this._material = material;
        }
        public Furniture(string name, string material, DateTime dateTime) : this(name, material)
        {
            this._age = dateTime;
        }

        public virtual void BreakTheFurniture()
        {
            _name = "Tarash";
            _age = DateTime.UtcNow;
        }
    }
    /// <summary>
    /// Наследник HomeFurniture от класса Furniture. 
    /// Не стоит настолько подробно наследовать класс.(Излишнее наследование)
    /// </summary>
    public class HomeFurniture : Furniture
    {
        public string Color { get; set; }
            
        public HomeFurniture(string name, string material, string color) : base(name, material)
        {
            this.Color = color;
            
        }

        public virtual bool IsComfortable()
        {
            return Material == "Wood";
        }
    }
    /// <summary>
    /// Наследник SleepFurniture от класса HomeFurniture.
    /// Не стоит настолько подробно наследовать класс.(Излишнее наследование)
    /// При изменении поведения родительского класса, может нарушится поведение дочерних.
    /// Не стоит плодить сильные связи без надобности.
    /// </summary>
    public class SleepFurniture : HomeFurniture
    {
        public SleepFurniture(string name, string material, string color) : base(name, material, color)
        {

        }

        public override bool IsComfortable() // изменения в базовом классе повлияют на работу переписанного метода
        {
            return base.IsComfortable();
        }

    }
    /// <summary>
    /// Наследник SofaBed от класса SleepFurniture.
    /// Не стоит настолько подробно наследовать класс.(Излишнее наследование)
    /// </summary>
    public class SofaBed : SleepFurniture
    {
        uint Legs { get; set; }

        public SofaBed(string name, string material, string color) : base(name, material, color)
        {

        }

        /// <summary>
        /// Желая переопределить метод разрушения мебели,
        /// мы переопределяем поведение метода не имея доступа к полям самого базового класса Furniture. 
        /// </summary>
        public override void BreakTheFurniture()
        {
            Color = "Black";
        }
    }
    /// <summary>
    /// Можно обойтись простым наследованием от Furniture и не создавать сложностей для поддержки.
    /// </summary>
    public sealed class Sofa : SofaBed
    {
        public Sofa(string name, string material, string color) : base(name, material, color)
        {

        }

        public override bool IsComfortable() // изменения в базовом классе повлияют на работу переписанного метода
        {
            return base.IsComfortable();
        }

        public override void BreakTheFurniture() // изменения в базовом классе повлияют на работу переписанного метода
        {
            base.BreakTheFurniture();
        }
    }
    /// <summary>
    /// Можно обойтись простым наследованием от Furniture и не создавать сложностей для поддержки.
    /// </summary>
    public sealed class Bed : SofaBed
    {
        public Bed(string name, string material, string color) : base(name, material, color)
        {

        }

        public override bool IsComfortable() // изменения в базовом классе повлияют на работу переписанного метода
        {
            return base.IsComfortable();
        }

        public override void BreakTheFurniture() // изменения в базовом классе повлияют на работу переписанного метода
        {
            base.BreakTheFurniture();
        }
    }
}
