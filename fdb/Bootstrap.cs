using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fdb.BoardBuilders;
using fdb.Models;
using SimpleInjector;

namespace fdb
{
    public class Bootstrap
    {
        public static Container Container;

        public static void Start()
        {
            Container = new Container();
            
            Container.Register<IGameBoardBuilder, MinesweeperBoardBuilder>(Lifestyle.Singleton);

            Container.Verify();
        }
    }
}
