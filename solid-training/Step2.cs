namespace solid_training
{
    /*
     Yapılan düzenlemeler;
        (S) Force sınıfı Single Responsibility aykırı olduğundan içindeki işlemler parçalandı.
        (O) Force sınıfı içinde bulunan move metodu if/enum ile Open/Close aykırı olduğundan içindeki koşulları
            gelişime açık bir şekilde değiştirerek sınıfları üzerinden yürütülmesi sağlandı.
        (L) -
        (I) -
        (D) Force sınıfı içinde bulunan, yazma işlemi interface ile türetilerek injection mantığında çalışması sağlandı.
     */

    internal class Step2
    {
        public Step2()
        {
            Console.WriteLine("-----Step2-----");

            Force t80 = new Tank();
            t80.Setup();
            t80.Move(10, 20, 30);

            Force readTeam = new Infantary();
            readTeam.Setup();
            readTeam.Move(10, 20, 30);
        }

        class Force
        {
            private IRouteSaver _saver;

            public Force()
            {
                _saver = (IRouteSaver)Activator.CreateInstance(Type.GetType(Configuration.Config["RouteSaver"]));
            }

            public virtual void Setup()
            {
                // Some setup operations
            }
            public virtual void Move(int x, int y, int z)
            {
                var routeInfo = $"{this.GetType().Name} to {x} {y} {z}"; ;
                Console.WriteLine(routeInfo);
                _saver.Write(routeInfo);
            }
        }

        interface IRouteSaver
        {
            void Write(string content);
        }

        class TextSaver : IRouteSaver
        {
            public void Write(string content)
            {
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "route2.txt"), content + "\n");
            }
        }

        class DBSaver : IRouteSaver
        {
            public void Write(string content)
            {
                // Save to DB
            }
        }

        class Tank : Force
        {
            public override void Setup()
            {
                base.Setup();
            }

            public override void Move(int x, int y, int z)
            {
                base.Move(x, y, z);
            }
        }

        class Infantary : Force
        {
            public override void Setup()
            {
                base.Setup();
            }

            public override void Move(int x, int y, int z)
            {
                base.Move(x, y, z);
            }
        }

        class Bastion: Force
        {
            public override void Setup()
            {
                base.Setup();
            }

            public override void Move(int x, int y, int z)
            {
                throw new Exception("Bu işlem desteklenmiyor");
            }
        }
    }
}
