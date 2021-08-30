using System;

namespace Fabric_Method_Pattern
{

    // Фабричный метод - это паттерн, который определяет интерфейс для создания объектов некоторого класса, но непосредственное решение о том, объект какого класса создавать, происходит в подклассах



    //1 пример

    abstract class GameDeveloper
    {
        public string Name { get; }
        public GameDeveloper(string name)
        {
            Name = name;
        }
        public abstract Game CreateGame();
    }
    class GameDeveloper2D : GameDeveloper
    {
        public GameDeveloper2D(string name) : base(name) { }
        public override Game CreateGame()
        {
            return new Game2D();
        }
    }
    class GameDeveloper3D : GameDeveloper
    {
        public GameDeveloper3D(string name) : base(name) { }
        public override Game CreateGame()
        {
            return new Game3D();
        }
    }
    abstract class Game 
    {
        public abstract void CreateGameMessage();
    }
    class Game2D : Game
    {
        public override void CreateGameMessage()
        {
            Console.WriteLine("2D Game was created");
        }
    }
    class Game3D : Game
    {
        public override void CreateGameMessage()
        {
            Console.WriteLine("3D Game was created");
        }
    }

    //2 пример
    abstract class Transport
    {
        public string Type { get; }
        public Transport(string Type)
        {
            this.Type = Type;
        }
    }
    class AutoMobile : Transport
    {
        public AutoMobile(string Type) : base(Type) { }

    }
    class Ship : Transport
    {
        public Ship(string Type) : base(Type) { }
    }
    class Train : Transport
    {
        public Train(string Type) : base(Type) { }
    }
    abstract class Logistic
    {
        public abstract Transport CreateTransport();
    }
    class AutoMobileLogistic : Logistic
    {
        public override Transport CreateTransport()
        {
            return new AutoMobile("Automobile");
        }
    }
    class ShipLogistic : Logistic
    {
        public override Transport CreateTransport()
        {
            return new Ship("Ship");
        }
    }
    class TrainLogistic : Logistic
    {
        public override Transport CreateTransport()
        {
            return new Train("Train");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 1 пример
            /*GameDeveloper gd = new GameDeveloper2D("2DGameDeveloper"); // Создаем класс 2Д разработчика и юзаем его унаследованное поле name и переопределенный метод CreateGame(), который в этом случае вернет объект класса Game2D
            Console.WriteLine(gd.Name);
            Game game = gd.CreateGame();
            game.CreateGameMessage();
            gd = new GameDeveloper3D("3DGameDeveloper"); // Создаем класс 3Д разработчика и юзаем его унаследованное поле name и переопределенный метод CreateGame(), который в этом случае вернет объект класса Game3D
            Console.WriteLine(gd.Name);
            game = gd.CreateGame();
            game.CreateGameMessage();*/

            // 2 пример
            //Автомбоильная логистика
            Logistic logistic = new AutoMobileLogistic();
            Transport transport = logistic.CreateTransport();
            Console.WriteLine(transport.Type);
            //Кораблевая логистика
            logistic = new ShipLogistic();
            transport = logistic.CreateTransport();
            Console.WriteLine(transport.Type);
            //Поездовая логистика
            logistic = new TrainLogistic();
            transport = logistic.CreateTransport();
            Console.WriteLine(transport.Type);
        }
    }
}
