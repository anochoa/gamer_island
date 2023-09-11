using Amiiboo.Tests.Configure;
using AutoMapper;
using GamesApi.Infra.Repository;
using GamesApi.Infra.Repository.Interfaces;
using GamesApi.Infra.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Amiiboo.Tests
{
    public class AmiibooServiceTests
    {
        private IAmiiboServices _services;
        private readonly Mock<IAmiiboRepository> _repositoryMock;
        private readonly Mock<IAmiiboServiceRest> _serviceRestMock;
        private readonly IMapper _mapper;

        public AmiibooServiceTests()
        {
            _serviceRestMock = new Mock<IAmiiboServiceRest>();
            _repositoryMock = AmiiboRepositoryMock.GetMock();
            _mapper = ConfigureMapper.GetMapper();
        }

        [Fact]
        public void GetFiltered_QuandoBucarPorTexto_DeveRetornarResultados()
        {
            //arrange
            _services = new AmiiboServices(_repositoryMock.Object, _serviceRestMock.Object, _mapper);
            string search = "Mario";
            //Act
            //var result = _services.GetFiltrado(new GamesApi.Infra.Modelo.Filter { CharName="Carlos" });
            var result = _services.GetFiltered(search);

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}