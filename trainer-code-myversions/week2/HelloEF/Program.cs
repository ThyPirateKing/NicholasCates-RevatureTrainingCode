using System;
using Microsoft.EntityFrameworkCore;

namespace HelloEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Pet myPet = new Pet{name = "Claude", cuteness = 9, chaos = 1000, species = "Cat"};

            myPet = CreatePet(myPet);

            //myPet = GetPet(myPet);
           
            Console.WriteLine(myPet.Speak());

            // List<Pet> petList = GetAllPets();

            // foreach (var p in petList)
            //     Console.WriteLine(p.Speak());

            // Pet returnedPet = GetPet(MyPet);
            // returnedPet = GetPetById(3);
            //bool confirm = UpdatePet(myPet);
            //bool confirm = DeletePet(myPet);
            //bool confirm = DeletePetById(2);
            //bool confirm = DeletePetByName("Claude");
            //bool confirm = DeleteAllPets();

            // Console.WriteLine(returnedPet?.Speak());
            // Console.WriteLine(confirm);
            // foreach (var p in petList)
            //     Console.WriteLine(p.Speak());

//I struggled to get this bit working, but we found a way around it!
/*
            //string ConnectionString = File.ReadAllText("./connectionstring");

            // DataContext Context = new DataContext(DbContextOptionsBuilder options => options.UseSqlServer(ConnectionString));
            // DataContext Context = new DataContext();

            //DbContextOptionsBuilder<DataContext> ContextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlServer(ConnectionString);
            //DataContext Context = new DataContext(ContextOptions.Options);
            // - Either Or -
            // DbContextOptions<DataContext> ContextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlServer(ConnectionString).Options;
            // DataContext Context = new DataContext(ContextOptions);
*/
        }

        public static Pet GetPet(Pet myPet)
        {
            using (var context = new DataContext())
            {
                List<Pet> petList = context.Pets.ToList();

                //LINQ
                    //Language Integrated Queury
                //We need an enumerable of things/objects to search through, and we can query against that enumerable.

                var found = // could be a single thing, could be a collection...
                    from p in context.Pets.ToList()
                    where p.name == myPet.name
                        && p.cuteness == myPet.cuteness
                        && p.chaos == myPet.chaos
                        && p.species == myPet.species
                    select p;
/*
                foreach(var p in found)
                    Console.WriteLine("Get Pet Method: " + "ID: " + p.id + " Pet Name: " + p.name);
            */

                return found.FirstOrDefault(); //this method is returning the first part of the found, which is the first of a collection in this situation.
            }
        }

        public static Pet GetPetByID(int id)
        {
            using (var context = new DataContext())
            {
                Pet pet = context.Pets.Find(id);
                return pet;
            }
        }

        public static Pet CreatePet(Pet newPet)
        {
            using (var context = new DataContext())
            {
                //we introduce the object to the context
                //The "context.Add(); method does not add to the database yet
                context.Add(newPet); 

                //we send/communicate to the db
                //(this is what slows down the program, only need to save probably at the end of manipulating the objects in the program)
                context.SaveChanges();

                // Needs to retrieve from the database!!!
                return GetPet(newPet);
            }
        }

        public static bool UpdatePet(Pet modifiedPet)
        {
            using (var context = new DataContext())
            {
                Pet savedPet = context.Pets.Find( modifiedPet.id );


                // if (context.Pets.Find(modifiedPet.Id) != null)
                if ( savedPet != null)
                {
                    // context.Add(modifiedPet);
                    savedPet.name = modifiedPet.name;
                    savedPet.cuteness = modifiedPet.cuteness;
                    savedPet.chaos = modifiedPet.chaos;
                    savedPet.species = modifiedPet.species;                    
                    
                     // only happens to the context, not the db yet...
                    context.SaveChanges(); // until we save to the db
                    // Would retun context.SaveChanges() > 1 work?
                    return true;
                }
                return false;
            }
        }

        public static bool DeletePet(Pet removePet)
        {
            using (var context = new DataContext())
            {
                bool check = true;

                if(context.Pets.Contains(removePet))
                {   
                    Console.WriteLine("Pet was removed!");
                    context.Pets.Remove(removePet);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Pet was NOT removed!");
                    check = false;
                }
                
                return check;

                /* this should be just 1 loop
                var removedPet = context.Pets.Remove(removePet);
                context.Pets.SaveChanges();
                return removedPet == null; //this may or may not work
                */

                /*
                    But wouldn't this run through the list twice? Instead of just once if Pet
                    is not in the list?
                    
                    What you have though would work for sure.
                
                I think this will work as well -Jean-Luc
                context.Remove(removePet); //This will track regardless if the object exists or not
                context.SaveChanges(); // TThis will call and attempt to delete but will just not update any rows when called
                
                Pet pet = GetPet(removePet); // This will check if the pet exists
                return pet == null; // This will return null or a pet (true or false);

                context.Pet.Remove also could return null on non-exist entries

                so it should be like this then?
                int changes = context.SaveChanges();
                if (changes == 0)
                    return false;
                else
                    return true;
    
                */
            }
        }

        public static bool DeletePetById(int id)
        {
            using (var context = new DataContext())
            {
                var pet = context.Pets.Find(id);
                if (pet != null)
                {
                    context.Pets.Remove(pet);
                    context.SaveChanges();
                    return !context.Pets.Contains(pet);
                }
                return false;
            }
        }

        public static bool DeletePetByName(string petName)
        {
            using (var context = new DataContext())
            {
                var pets = from p in context.Pets.ToList()
                           where p.name == petName
                           select p;
                bool deleted = false;
                 
                foreach (var pet in pets)
                {
                    context.Pets.Remove(pet);
                    deleted = true;
                }

                context.SaveChanges();
                return deleted;
            }
        }

        public static bool DeleteAllPets()
        {
            using (var context = new DataContext())
            {
                // alt: context.Pets.RemoveRange(context.Pets);
                foreach (var pet in context.Pets)
                {
                    context.Pets.Remove(pet);
                    // alt2: DeletePet(pet);
                }
                context.SaveChanges();
                return !context.Pets.Any();
                // alt3: context.Database.ExecuteSqlCommand("TRUNCATE TABLE Pets");
            }
        }

        public static List<Pet> GetAllPets()
        {
            using (var context = new DataContext())
            {
                //Console.WriteLine(context.Pets.Count);
                return context.Pets.ToList();
            }
        }
    }

    public class Pet
    {
        //POCCO
            //Plain Old C# Object (Plain Old CLR Object)
        //Fields
        public int id{ get; set; }
        public string? name { get; set; }
        public int? cuteness{ get; set; }
        public long? chaos{ get; set; }
        public string? species{ get; set; }
        //public public int OwnerID{ get; set; } //1:1
        public List<Owner> Owners{ get; set; } // 1 to many when it's just one and not also in pet

        //Constructors
        //Methods
        public string Speak()
        {
            return $"Hello, I'm {this.name}!, I have ID #{this.id}, I'm {this.cuteness} cute, {this.chaos} chaotic, and a {this.species}.";
        }
    }

    public class Owner
    {
        public int id{ get; set;}
        public string? name { get; set;}
        public List<Pet> Pets { get; set; } //many to many when you have the other one in Pet

        public string Speak()
        {
            return $"Hello, I'm {this.name}.";
        }
    }

    class DataContext : DbContext
    {
        string ConnectionString = File.ReadAllText("./connectionstring");

        //Fields
        public DbSet<Pet> Pets => Set<Pet>(); //"Pets" is the name of the table in the database

        //Constructors
        //public DataContext(DbContextOptions<DataContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }

}