using GamesApi.Infra.Repository;
using GamesApi.Infra.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amiiboo.Tests.Configure
{
    internal class AmiiboooLogRepositoryMock
    {
        public static Mock<IAmiiboooLogRepository> GetMock()
        {
            var repositoryMock = new Mock<IAmiiboooLogRepository>();
            repositoryMock.Setup(x => x.CreateMore(GetData())).Callback(() => { return; });
            return repositoryMock;
        }

        private static List<Amiibooo> GetData()
        {
            var dados = new List<Amiibooo> {
                new Amiibooo
                {
                    AmiiboSeries = "AmiboSerieTest",
                    GameSeries = "GameSeriesMario",
                    Name = "Mario",
                    Head = "Mario",
                    Image = "Mario",
                    Tail = "Mario",
                    Thecharacter = "Mario",
                    Type = "Mario",
                    Id = 1,
                    Data = DateTime.Now
                }
            };
            return dados;
        }
    }
}
