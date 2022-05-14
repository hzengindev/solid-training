namespace solid_training
{
    /*
     Yapılan düzenlemeler;

        (S) Force sınıfı Single Responsibility aykırı olduğundan içindeki işlemler parçalandı.
        
        (O) Force sınıfı içinde bulunan move metodu if/enum ile Open/Close aykırı olduğundan içindeki koşulları
            gelişime açık bir şekilde değiştirerek sınıfları üzerinden yürütülmesi sağlandı.
        
        (L) Force sınıfı çok genel bir sınıf olduğundan, süreci genişletmek, yeni force tipleri eklemek istediğimizde
            her force tipinde "move" özelliği olmayabilir. Bu yüzden force sınıfına ait özellikler ayrı interfaceler oluşturularak tanımlanabilir.
            Yeni eklenen force tipine göre sadece ilgil interface (ISetup) eklenerek sürece devam edilebilir.
            Desteklenmeyen durumların not implemented/unsupported gibi exception tiplerinde fırlatılması bu duruma aykırı oluyor.        
            Bu sayede alt sınıflar üst sınıfların tüm özellikleri ya da tam tersi durumu tam anlamıyla desteklemiş olur.        
        
        (I) Mevcut interface tanımları üzerinde yeni özellikler eklendiğinde, eklenen bu özelliklerin her sınıf içinde implement edilmesi gerekmektedir.
            Bu durum bazı force tipindeki sınıflara ihtiyaç olmayabilir. Bu durumda sınıf içinde gereksiz kod karmaşası yada unsupported throw düzenlemeleri
            yapılacağından bu istenmeyen bir durum. Bu durumu çözmek için ilgili yeni özellik yeni bir interface ile eklenerek sadece bu özelliği kullanacak
            sınıflar üzerinde implemente edilebilir. "ILocationCheck"
        
        (D) Force sınıfı içinde bulunan, yazma işlemi interface ile türetilerek injection mantığında çalışması sağlandı.
     */

    internal class Step3
    {
        public Step3()
        {
            Console.WriteLine("-----Step3-----");

            List<Force> forces = new List<Force>()
            {
                new Tank(),
                new Infantary(),
            };

            foreach (var force in forces)
            {
                force.Setup();
                force.Move(10, 20, 30);
            }

            var paratrooper = new Paratrooper();
            paratrooper.Setup();
            paratrooper.Move(10, 20, 30);
            paratrooper.Check();
        }

        interface IMovement
        {
            void Move(int x, int y, int z);
        }

        interface ISetup
        {
            void Setup();
        }

        interface ILocationControl
        {
            bool Check();
        }

        class Force : IMovement, ISetup
        {
            private IRouteSaver _saver;

            public Force()
            {
                //_saver = (IRouteSaver)Activator.CreateInstance(Type.GetType(Configuration.Config["RouteSaver"]));
                _saver = new TextSaver();
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
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "route3.txt"), content + "\n");
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

        class Bastion: ISetup
        {
            public void Setup()
            {
                // doing somethings
            }
        }

        class Paratrooper : Force, ILocationControl
        {
            public override void Setup()
            {
                base.Setup();
            }

            public override void Move(int x, int y, int z)
            {
                base.Move(x, y, z);
            }

            public bool Check()
            {
                // doing some controls
                Console.WriteLine("Paratrooper Location Check");
                return true;
            }
        }
    }
}
