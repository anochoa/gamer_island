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
    internal class AmiiboRepositoryMock
    {
        public static Mock<IAmiiboRepository> GetMock()
        { 
             var repositoryMock = new Mock<IAmiiboRepository>();

            //repositoryMock.Setup(x =>
            //                    x.FindAll(x =>
            //                            x.Name.Contains(It.IsAny<string>())
            //                            || x.Thecharacter.Contains(It.IsAny<string>())
            //                            || x.GameSeries.Contains(It.IsAny<string>())))
            //    .Returns(GetData());

            repositoryMock.Setup(x =>
                               x.FindAll(It.IsAny<Expression<Func<Amiibo, bool>>>()))
               .Returns(GetData());

            repositoryMock.Setup(x => x.CreateMore(GetData())).Callback(() => { return; });


            return repositoryMock;
        }

        private static List<Amiibo>  GetData()
        {
            var dados = new List<Amiibo> {
                new Amiibo
                {
                    AmiiboSeries = "AmiboSerieTest",
                    GameSeries = "GameSeriesMario",
                    Name = "Mario",
                    Head = "Mario",
                    Image = "Mario",
                    Tail = "Mario",
                    Thecharacter = "Mario",
                    Type = "Mario",
                    Id = 1
                }
            };
            return dados;
        }
    }
}
