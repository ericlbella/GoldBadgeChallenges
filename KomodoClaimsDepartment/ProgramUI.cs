using ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();

        // Method that runs/starts the application
        public void Run()
        {
            SeedClaimsQueue();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Choose a menu item:\n\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // See All Claims
                        SeeAllClaims();
                        break;
                    case "2":
                        // Take Care of Next Claim
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        // Enter a New Claim
                        EnterANewClaim();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        // View all claims
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _claimsRepo.GetClaimsQueue();

            string[] columnHeaders = { "Claim ID", "Type", "Description", "Amount", "Date of Accident", "Date of Claim", "Is Valid"};
           Console.WriteLine($"{columnHeaders[0], 3} {columnHeaders[1], 10} {columnHeaders[2], 25} {columnHeaders[3], 20} {columnHeaders[4], 20} {columnHeaders[5], 20} {columnHeaders[6], 18}");
            

            foreach(Claims claims in queueOfClaims)
            {
                Console.WriteLine($"{claims.ClaimID,3} {claims.TypeOfClaim,15} {claims.Description,30} {claims.ClaimAmount,15:C} {claims.DateOfIncident.ToShortDateString(),20} {claims.DateOfClaim.ToShortDateString(),20} {claims.IsValid,18}");
            }
        }


        // Next claim
        private void TakeCareOfNextClaim()
        {
            Queue<Claims> claims = _claimsRepo.GetClaimsQueue();
            Claims claim = claims.Peek();

            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                $"Type of Claim: {claim.TypeOfClaim}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.ClaimAmount}\n" +
                $"Date Of Accident: ${claim.DateOfIncident}\n" +
                $"Date Of Claim: {claim.DateOfClaim}\n" +
                $"Is Valid: {claim.IsValid}");

            Console.WriteLine("Would you like to take care of this claim?");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                claims.Dequeue();
                Menu();
            }
            else
            {
                Menu();
            }
        }

        // Create new Claim
        private void EnterANewClaim()
        {
            Console.Clear();
            Claims newClaims = new Claims();

            // Claim ID
            Console.WriteLine("Enter the claim id for the claim:");
            string claimNumber = Console.ReadLine();
            newClaims.ClaimID = int.Parse(claimNumber);

            // Type of Claim
            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            string typeOfClaim = Console.ReadLine();
            int claimAsInt = int.Parse(typeOfClaim);
            newClaims.TypeOfClaim = (ClaimType)claimAsInt;

            // Description
            Console.WriteLine("Enter the description for the claim:");
            newClaims.Description = Console.ReadLine();

            // Claim Amount
            Console.WriteLine("Enter the decimal value of the claim amount:");
            string amount = Console.ReadLine();
            newClaims.ClaimAmount = decimal.Parse(amount);

            // Date of Incident
            Console.WriteLine("Enter the date of the accident (ex. nmm/dd/yy :");
            string dateAccident = Console.ReadLine();
            newClaims.DateOfIncident = DateTime.Parse(dateAccident);

            // Date of Claim
            Console.WriteLine("Enter the date of the claim (ex. mm/dd/yy:");
            string dateClaim = Console.ReadLine();
            newClaims.DateOfClaim = DateTime.Parse(dateClaim);

            // Is Valid

            if ((newClaims.DateOfClaim - newClaims.DateOfIncident).Days <= 30)
            {
                newClaims.IsValid = true;
            }
            else
            {
                newClaims.IsValid = false;
            }

            _claimsRepo.AddClaimsToQueue(newClaims);
        }
    
        // Seed method
        private void SeedClaimsQueue()
        {
            var dateOfAccident1 = new DateTime(2018, 04, 25);
            var dateOfClaim1 = new DateTime(2018, 04, 27);

            var dateOfAccident2 = new DateTime(2018, 04, 11);
            var dateOfClaim2 = new DateTime(2018, 04, 12);

            var dateOfAccident3 = new DateTime(2018, 04, 27);
            var dateOfClaim3 = new DateTime(2018, 06, 01);

            Claims claim1 = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, dateOfAccident1, dateOfClaim1, true);
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, dateOfAccident2, dateOfClaim2, true);
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, dateOfAccident3, dateOfClaim3, false);

            _claimsRepo.AddClaimsToQueue(claim1);
            _claimsRepo.AddClaimsToQueue(claim2);
            _claimsRepo.AddClaimsToQueue(claim3);
        }
    }
}
