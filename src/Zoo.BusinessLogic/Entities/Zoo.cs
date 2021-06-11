using System;
using System.Collections.Generic;

namespace Zoo.BusinessLogic

{
    public class Zoo : ZooApp
    {
        private readonly IConsole zooConsole;
        public Zoo(IConsole console = null)
        {
            zooConsole = console;
            zooConsole?.WriteLine("a Zoo was created without concrete location");
        }
        public Zoo(string location, IConsole console = null)
        {
            Location = location;
            zooConsole = console;
            zooConsole?.WriteLine($"a Zoo was created in {Location}");
        }

        public int StartingId { get; internal set; } = 1;
        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();
        public List<IEmployee> Employees { get; private set; } = new List<IEmployee>();

        public string Location { get; private set; }

        public void AddLocation(string anyLocation)
        {
            Location = anyLocation;
            zooConsole?.WriteLine($"The location was changed to {Location} ");
        }

        public Enclosure AddEnclosure(string name, int squreFeet)
        {
            Enclosure enclosure = new Enclosure(this, name, squreFeet);
            Enclosures.Add(enclosure);
            zooConsole?.WriteLine($"An enclousure was created. The enclousure's was set to {enclosure.Name}, it's area is {enclosure.SqureFeet} sq. feet ");
            return enclosure;
        }

        public Enclosure FindAvailableEnclosure(Animal animal)
        {
            foreach (var enclosure in Enclosures)
            {
                if (enclosure.SqureFeet >= animal.RequiredFeet && enclosure.IsFriendlyTo(animal))
                {
                    zooConsole?.WriteLine($"Enclosure {enclosure.Name} was found");
                    return enclosure;
                }
            }
            zooConsole?.WriteLine($"There is no available enclosure");
            throw new NoAvailableEnclosureException();
        }

        public void HireEmployee(IEmployee employee)
        {
            HireValidatorProvider validatorProvider = new();
            IHireValidator employeeValidator = validatorProvider.GetHireValidator(employee);
            List<ValidationError> errors = employeeValidator.ValidateEmployee(employee, this);

            if (errors.Count == 0)
            {
                Employees.Add(employee);
                zooConsole?.WriteLine($"{employee.GetType().Name} was hired");
            }
            else
            {
                zooConsole?.WriteLine($"The employee has no required expirience");
                throw new NoNeededExperienceException();
            }
        }

        public void FeedAnimals()
        {
            if (Employees.Count != 0)
            {
                List<IEmployee> ZooKeepers = new List<IEmployee>();

                foreach (var employee in Employees)
                {
                    if (employee.GetType().Name == typeof(ZooKeeper).Name)
                    {
                        ZooKeepers.Add(employee);
                    }
                }

                if (ZooKeepers.Count != 0)
                {

                    List<Animal> animalsToFeed = new List<Animal>();
                    foreach (var enclosure in Enclosures)
                    {
                        foreach (var animal in enclosure.Animals)
                        {
                            animalsToFeed.Add(animal);
                        }
                    }

                    int index = animalsToFeed.Count / ZooKeepers.Count;

                    List<Animal> firstGroup = new List<Animal>();
                    for (int i = 0; i < index; i++)
                    {
                        firstGroup.Add(animalsToFeed[i]);
                    }

                    List<Animal> secondGroup = new List<Animal>();
                    for (int i = index; i < animalsToFeed.Count; i++)
                    {
                        secondGroup.Add(animalsToFeed[i]);
                    }

                    foreach (var animal in firstGroup)
                    {
                        (ZooKeepers[0] as ZooKeeper).FeedAnimal(animal);
                        zooConsole?.WriteLine($"{animal.GetType().Name} was fed by {ZooKeepers[0].FirstName} {ZooKeepers[0].LastName}");
                    }
                    foreach (var animal in secondGroup)
                    {
                        (ZooKeepers[1] as ZooKeeper).FeedAnimal(animal);
                        zooConsole?.WriteLine($"{animal.GetType().Name} was fed by {ZooKeepers[1].FirstName} {ZooKeepers[1].LastName}");
                    }
                }
                else
                {
                    zooConsole?.WriteLine($"Zoo has no zookeeper, hire at least one");
                    throw new NoNeededEmployeeException();
                }
            }
            else
            {
                zooConsole?.WriteLine($"Zoo has no zookeeper, hire at least one");
                throw new NoEmployeesException();
            }
        }

        public void HealAnimals()
        {
            if (Employees.Count != 0)
            {
                List<IEmployee> Veterinarians = new List<IEmployee>();

                foreach (var employee in Employees)
                {
                    if (employee.GetType().Name == typeof(Veterinarian).Name)
                    {
                        Veterinarians.Add(employee);
                    }
                }

                if (Veterinarians.Count != 0)
                {
                    foreach (var veterinarian in Veterinarians)
                    {
                        foreach (var enclosure in Enclosures)
                        {
                            foreach (var creature in enclosure.Animals)
                            {
                                (veterinarian as Veterinarian).HealAnimal(creature);
                                zooConsole?.WriteLine($"{creature.GetType().Name} was heal by {veterinarian.FirstName} {veterinarian.LastName}");
                            }
                        }
                        break;
                    }
                }
                else
                {
                    zooConsole?.WriteLine($"Zoo has no veterinarian, hire at least one");
                    throw new NoNeededEmployeeException();
                }
            }
            else
            {
                zooConsole?.WriteLine($"Zoo has no veterinarian, hire at least one");
                throw new NoEmployeesException();
            }
        }
    }
}