﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test.ValidationTests
{
    public class ZooKeeperHireValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToCreateZooKeeperHireValidator()
        {
            ZooKeeperHireValidator zooKeeperHireValidator = new();

        }

        [Fact]
        public void ShouldBeAbleToValidateEmployeeAsZooKeeper()
        {
            Zoo zoo = new Zoo();
            ZooKeeperHireValidator zooKeeperHireValidator = new();
            IEmployee employee = new ZooKeeper("First Name", "Last Name");
            List<ValidationError> errors = zooKeeperHireValidator.ValidateEmployee(employee, zoo);
        }

    }
}
