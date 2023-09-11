using Amiiboo.Tests.Configure;
using AutoMapper;
using gamesapi.Controllers;
using GamesApi.Infra.Modelo;
using GamesApi.Infra.Repository.Interfaces;
using GamesApi.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Amiiboo.Tests
{
    public class AmiibooControllerTests
    {
        private IAmiiboServices _services;
        private readonly Mock<IAmiiboRepository> _repositoryMock;
        private readonly Mock<IAmiiboooLogRepository> _repositoryLogMock;
        private readonly Mock<IAmiiboServiceRest> _serviceRestMock;
        private readonly IMapper _mapper;

        public AmiibooControllerTests()
        {
            _serviceRestMock = new Mock<IAmiiboServiceRest>();
            _repositoryMock = AmiiboRepositoryMock.GetMock();
            _repositoryLogMock = AmiiboooLogRepositoryMock.GetMock();
            _mapper = ConfigureMapper.GetMapper();
        }


        [Fact]
        public void GetData_DeveRetornarDados_QuandoBuscarPorDadoValido()
        {

            var amiiboServices = new AmiiboServices(_repositoryMock.Object, _serviceRestMock.Object, _mapper);
            var amiibooLogServices = new AmiiboooLogServices(_repositoryLogMock.Object, _mapper);
            
            string search = "Mario";

            var controller = new AmiiboController(amiiboServices, amiibooLogServices);

            var result = controller.GetData(search) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<AmiiboDTO>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<AmiiboDTO>);

        }
    }
}
