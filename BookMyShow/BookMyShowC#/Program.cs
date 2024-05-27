
namespace Book_My_Show
{
    public class Program 
    {
        static void Main(string[] args) 
        {
            int a = 10, b = 20;
            Swap(ref a, ref b);
            Console.WriteLine($"{a} {b}");
        }
        static void Swap<T>(ref T a, ref T b) 
        {
            (a, b) = (b, a);
        }
    }


    abstract class GeoShape
    {
        public int Dim1 { get; set; }
        public int Dim2 { get; set; }
        public GeoShape(int D1, int D2)
        {
            Dim1 = D1;
            Dim2 = D2;
        }
        public abstract double Area();
        public abstract double Perimeter { get; }
    }

    class Rect: GeoShape
    {
        public Rect(int W, int H): base(W, H) {}

        public override double Perimeter => 2 * (Dim1 + Dim2);

        public override double Area() => Dim1 * Dim2;
        
    }

    abstract class Person
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public Person(string _FName, string _LName) 
        {
            FName = _FName;
            LName = _LName;
        }
        public override string ToString()
        {
            return $"{FName} {LName}";
        }
    }

    class TypeA 
    {
        public int A { get; set; }
        public TypeA(int _A = 0) 
        {
            A = _A;
        }
        public void StaticallyBindedShow()
        {
            Console.WriteLine("I am Base");
        }
        internal virtual void DynShow()
        {
            Console.WriteLine("I am Base");
        }
    }

    class TypeB: TypeA
    {
        public int B { get; set; }
        public TypeB(int _A = 0, int _B = 0): base(_A)
        {
            B = _B;
        }
        public new void StaticallyBindedShow()
        {
            Console.WriteLine("I am Derived");
        }
        internal override void DynShow()
        {
            Console.WriteLine("I am Derived");
        }
    }

    class TypeC: TypeB
    {
        public int C { get; set; }
        public TypeC(int _a, int _b, int _c) : base(_a, _b)
        {
            C = _c;
        }
        internal override void DynShow()
        {
            Console.WriteLine($"Type C {A}, {B}, {C}");
        }
    }
}