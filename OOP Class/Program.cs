namespace OOP_Class
{
    internal class Program
    {
        enum Cartype { Truck, Bus}

        class Car // 객체 생성
        {
            // 객체 정보
            public string name;
            public float speed;
            public Cartype type;

            private bool turnOn; // 외부에서 시동 여부를 바꿀 수 없다
            public int oilAmount;

            //객체 기능(함수)
            public void SpeedUp()
            {
                Console.WriteLine($"{name} 이름의 차가 속도를 높입니다");
                speed += 10;
            }

            public void Move()
            {
                Console.WriteLine($"{name} 이름의 차가 이동합니다");
                Console.WriteLine($"{name} 이름의 차가 기름 10을 소모합니다");
                oilAmount -= 10;
            }

            public void Stop()
            {
                Console.WriteLine($"{name} 이름의 차가 멈춥니다");
                speed = 0;
            }

            public void TurnOn()
            {
                Console.WriteLine($"{name} 이름의 차는 {oilAmount}양만큼 기름을 가지고 있습니다");
                if (oilAmount > 0)
                {
                    Console.WriteLine("시동이 걸립니다");
                    turnOn = true;
                }
                else
                {
                    Console.WriteLine("기름이 없어서 시동이 걸리지 않습니다");
                }
            }

            public void TurnOff()
            {
                Console.WriteLine("시동이 꺼집니다");
                turnOn = false;
            }
        }

        class Player
        {
            private int hp = 100; // 외부에서 플레이어를 쓰러트리지 못하도록 함

            public void TakeDamage(int damage)
            {
                Console.WriteLine($"플레이어가 {damage}만큼 공격받았습니다");
                hp -= damage;
                Console.WriteLine($"플레이어의 남은 체력은 {hp}입니다");
                if (hp <= 0)
                {
                    Die();
                }
            }

            private void Die()
            {
                Console.WriteLine("플레이어가 쓰러집니다");
            }
        }

        class Monster
        {
            public string name;
            public int attackPoint;
            public void Attack(Player player)
            {
                Console.WriteLine($"{name} 이름의 몬스터가 {attackPoint} 데미지로 플레이어를 공격합니다");
                player.TakeDamage(attackPoint);
            }
        }

        static void Main(string[] args)
        {
            #region 객체 사용 전
            // 의도된 수행
            string carName = "봉고";
            float carSpeed = 0;
            Cartype carType = Cartype.Truck;
            Console.WriteLine($"{carName}의 속도는 {carSpeed}입니다");
            DriveCar(carName, ref carSpeed, carType);
            Console.WriteLine($"함수 수행 결과 {carName}의 속도는 {carSpeed}입니다");
            Console.WriteLine();

            // 의도하지 않은 수행
            string playerName = "김전사";
            float playerCritical = 0.3f;
            Console.WriteLine($"{playerName}의 치명타는 {playerCritical}입니다");
            DriveCar(playerName, ref playerCritical, carType);
            Console.WriteLine($"함수 수행 결과 {playerName}의 치명타는 {playerCritical}입니다");
            Console.WriteLine();
            // 문법적으로 오류는 없으나 의도하지 않게 김전사의 critical을 올림
            #endregion

            #region 객체 사용 후
            // 객체 사용
            Car bongo = new Car(); // bongo 이름을 가진 새로운 Car 객체를 만듬
            // 정보 입력
            bongo.name = "봉고";
            bongo.speed = 0;
            bongo.type = Cartype.Truck;
            bongo.oilAmount = 10;
            // bongo.turnOn = true; 는 private 처리되어 외부 변경이 불가능하다

            // 함수 사용
            bongo.TurnOn();
            bongo.SpeedUp();
            bongo.Move();
            bongo.Stop();
            bongo.TurnOff();

            bongo.TurnOn();
            // Car에 포함되지 않은 정보는 함수를 사용할 수 없다
            Console.WriteLine();
            #endregion

            #region Player와 Monster 객체의 상호작용
            Player player = new Player();
            player.TakeDamage(10);
            
            // 몬스터 생성
            Monster orc = new Monster();
            orc.name = "오크";
            orc.attackPoint = 15;

            Monster slime = new Monster();
            slime.name = "슬라임";
            slime.attackPoint = 5;
            
            Monster dragon = new Monster();
            dragon.name = "드레곤";
            dragon.attackPoint = 70;

            // 몬스터의 공격
            orc.Attack(player);
            slime.Attack(player);
            dragon.Attack(player);
            #endregion
        }

        static void DriveCar(string carName, ref float carSpeed, Cartype cartype)
        {
            Console.WriteLine($"{carName} 이름의 차가 속도를 높입니다.");
            carSpeed += 10;
        }

        static void StopCar(string carName, ref float carSpeed, Cartype cartype)
        {
            Console.WriteLine($"{carName} 이름의 차가 멈춥니다");
            carSpeed = 0;
        }
    }
}
