using System;
using Xunit;

namespace Zoo.Programm.Test
{
    public class ProgrammTest
    {
        [Fact]
        public void ShoulRunProgramm()
        {
            Zoo.ConsoleApp.RunZooApp.RunZoo();
        }
    }
}
