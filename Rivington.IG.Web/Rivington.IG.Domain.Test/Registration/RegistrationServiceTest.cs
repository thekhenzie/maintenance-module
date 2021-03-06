﻿using Rivington.IG.Domain.ExceptionsThrown;
using Rivington.IG.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Rivington.IG.Domain.Test.Registration
{
    [TestClass]
    public class RegistrationServiceTest
    {
        // global variables
        private string username;
        private string password;
        private RegistrationService sut;

        //private Mock<IAccountRepository> mockRepository; // set mock

        // initialize fresh AF variables for every test methods
        [TestInitialize]
        public void Initialize()
        {
            //username = "aterrible@blastasia.com";
            //password = "Bl@st123";

            //mockRepository = new Mock<IAccountRepository>(); //instantiate mockRepository
            //sut = new RegistrationService(mockRepository.Object); //pass the mockrepositry to be a copy as an Object

        }

        // Clean up every Initialized variables needed to be cleaned
        [TestCleanup]
        public void Cleanup()
        {

        }

        // Check Valid username and password
        [TestMethod]
        [Owner("Topeng")]
        [Description("Check Valid username and password")]
        public void Register_ValidUserNameAndPassword_RegistersAccount()
        {
            // Arrange
            var expectedResult = true;
            //Act
            bool actualResult = sut.Register(username, password);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        // Username Required
        [TestMethod]
        [Owner("Topeng")]
        [Description("Check when Username is blank, it should throw UsernameRequiredException")]
        public void Register_BlankUsername_ThrowsUsernameRequiredException()
        {
            // Arrange
            var username = "";
            //Assert
            Assert.ThrowsException<UsernameRequiredException>(
                () => sut.Register(username, password));
        }

        // Invalid Email format
        [DataTestMethod]
        [DataRow("cmanuel@blastasiacom")]
        [DataRow("cmanuel@blastasia")]
        [DataRow("cmanuel.blastasia.com")]
        [Owner("Topeng")]
        [Description("Check when Username is invalid format, it should throw InvalidUsernameException")]
        public void Register_InvalidEmail_ThrowsInvalidEmailException(string username)
        {
            //Assert
            Assert.ThrowsException<InvalidUsernameException>(
                () => sut.Register(username, password));
        }

        // Password Required
        [TestMethod]
        [Owner("Chris")]
        [Description("Check when password is blank, it should throw PasswordRequiredException")]
        public void Register_BlankPassword_ThrowsPasswordRequiredException()
        {
            // Arrange
            var password = "";
            //Assert
            Assert.ThrowsException<PasswordRequiredException>(
                () => sut.Register(username, password));
        }

        // Password Length (currently minimum is 8)
        [TestMethod]
        [Owner("Chris")]
        [Description("Check when password is below minimum length requirement, it should throw MinimumPasswordLengthRequiredException")]
        public void Register_MinimunLengthPasswordRequired_ThrowsMinimunPasswordLengthException()
        {
            // Arrange
            var password = "Bl@st12";
            //Assert
            Assert.ThrowsException<MinimumPasswordLengthRequiredException>(
                () => sut.Register(username, password));
        }

        // Strong password checking
        [DataTestMethod]
        [DataRow("bl@st123")]
        [DataRow("BL@ST123")]
        [DataRow("Bl@staasd")]
        [DataRow("Blast123")]
        [Owner("Chris")]
        [Description("Check for Invalid Password / Not Strong password")]
        public void Register_NotStrongPassword_ThrowsStrongPasswordException(string password)
        {
            //Assert
            Assert.ThrowsException<StrongPasswordException>(
                () => sut.Register(username, password));
        }

        [TestMethod]
        public void Register_withValidUserNameAndPasswordShouldCallDependencies()
        {
            // act
            sut.Register(username, password); // call the Register method on sut
            // assert
            //mockRepository // then finally assert
            //        .Verify(r => r.Create(It.IsAny<Account>()),
            //                    Times.Once());
        }
    }
}
