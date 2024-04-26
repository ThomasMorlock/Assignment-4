using Clients;

Client myClient = new();
List<Client> listOfClients = [];

LoadFileValuesToMemory(listOfClients);

bool loopAgain = true;
while (loopAgain)
{
	try
	{
		DisplayMainMenu();
		string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
		if (mainMenuChoice == "N")
			myClient = NewClient();
		if (mainMenuChoice == "S")
			ShowClientInfo(myClient);
		if (mainMenuChoice == "A")
			AddPetToList(myPet, listOfPets);
		if (mainMenuChoice == "F")
			myPet = FindPetInList(listOfPets);
		if (mainMenuChoice == "R")
			RemovePetFromList(myPet, listOfPets);
		if (mainMenuChoice == "D")
			DisplayAllPetsInList(listOfPets);
		if (mainMenuChoice == "Q")
		{
			SaveMemoryValuesToFile(listOfPets);
			loopAgain = false;
			throw new Exception("Bye, hope to see you again.");
		}
		if (mainMenuChoice == "E")
		{
			while (true)
			{
				DisplayEditMenu();
				string editMenuChoice = Prompt("\nEnter a Edit Menu Choice: ").ToUpper();
				if (editMenuChoice == "T")
					GetTag(myPet);
				if (editMenuChoice == "N")
					GetName(myPet);
				if (editMenuChoice == "A")
					GetAge(myPet);
				if (editMenuChoice == "W")
					GetWeight(myPet);
				if (editMenuChoice == "P")
					GetType(myPet);
				if (editMenuChoice == "R")
					throw new Exception("Returning to Main Menu");
			}
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine($"{ex.Message}");
	}
}

void DisplayMainMenu()
{
	Console.WriteLine("\nMain Menu");
	Console.WriteLine("N) New Client PartA");
	Console.WriteLine("S) Show Client BMI Info PartA");
	Console.WriteLine("E) Edit Client Info PartA");
	Console.WriteLine("A) Add Pet To List PartB");
	Console.WriteLine("F) Find Pet In List PartB");
	Console.WriteLine("R) Remove Pet From List PartB");
	Console.WriteLine("D) Display all Pets in List PartB");
	Console.WriteLine("Q) Quit");
}

void DisplayEditMenu()
{
	Console.WriteLine("Edit Menu");
	Console.WriteLine("T) Tag");
	Console.WriteLine("N) Name");
	Console.WriteLine("A) Age");
	Console.WriteLine("W) Weight");
	Console.WriteLine("P) Type");
	Console.WriteLine("R) Return to Main Menu");
}

void ShowClientInfo(Client client)
{
	if(client == null)
		throw new Exception($"No Pet In Memory");
	Console.WriteLine($"\n{client.ToString()}");
	Console.WriteLine($"BMI Score    :\t{client.BmiScore:n4}");
	Console.WriteLine($"BMI Status   :\t{client.BmiStatus:n4}");
}

string Prompt(string prompt)
{
	string myString = "";
	while (true)
	{
		try
		{
		Console.Write(prompt);
		myString = Console.ReadLine().Trim();
		if(string.IsNullOrEmpty(myString))
			throw new Exception($"Empty Input: Please enter something.");
		break;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return myString;
}

double PromptDoubleBetweenMinMax(String msg, double min, double max)
{
	double num = 0;
	while (true)
	{
		try
		{
			Console.Write($"{msg} between {min} and {max} inclusive: ");
			num = double.Parse(Console.ReadLine());
			if (num < min || num > max)
				throw new Exception($"Must be between {min:n2} and {max:n2}");
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Invalid: {ex.Message}");
		}
	}
	return num;
}

Client NewClient()
{
	//Console.WriteLine("Not Implemented Yet PartA");
	Client myClient = new();
	GetFirstName(myClient);
	GetLastName(myClient);
	GetWeight(myClient);
	GetHeight(myClient);
	return myClient;
}

void GetFirstName(Client client)
{
	//Console.WriteLine("Not Implemented Yet PartA");
	string myString = Prompt($"Enter First Name: ");
	client.FirstName = myString;
}

void GetLastName(Client client)
{
	//Console.WriteLine("Not Implemented Yet PartA");
	string myString = Prompt($"Enter Last Name: ");
	client.LastName = myString;
}

void GetWeight(Client client)
{
	//Console.WriteLine("Not Implemented Yet PartA");
	int myInt = PromptDoubleBetweenMinMax("Enter Weight in pounds(lbs): ", 0, 120);
	client.Weight = myDouble;
}

void GetHeight(Client client)
{
	//Console.WriteLine("Not Implemented Yet PartA");
	double myDouble = PromptDoubleBetweenMinMax("Enter Weight in inches: ", 0, 120);
	client.Height = myDouble;
}



void AddPetToList(Pet myPet, List<Pet> listOfPets)
{
	//Console.WriteLine("Not Implemented Yet PartB");
	listOfPets.Add(myPet);
}

Pet FindPetInList(List<Pet> listOfPets)
{
	Console.WriteLine("Not Implemented Yet PartB");
	return new Pet();
}

void RemovePetFromList(Pet myPet, List<Pet> listOfPets)
{
	Console.WriteLine("Not Implemented Yet PartB");
}

void DisplayAllPetsInList(List<Pet> listOfPets)
{
	//Console.WriteLine("Not Implemented Yet PartB");
	foreach(Pet pet in listOfPets)
		ShowPetInfo(pet);
}

void LoadFileValuesToMemory(List<Pet> listOfPets)
{
	while(true){
		try
		{
			//string fileName = Prompt("Enter file name including .csv or .txt: ");
			string fileName = "regin.csv";
			string filePath = $"./data/{fileName}";
			if (!File.Exists(filePath))
				throw new Exception($"The file {fileName} does not exist.");
			string[] csvFileInput = File.ReadAllLines(filePath);
			for(int i = 0; i < csvFileInput.Length; i++)
			{
				//Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
				string[] items = csvFileInput[i].Split(',');
				for(int j = 0; j < items.Length; j++)
				{
					//Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
				}
				Pet myPet = new(items[0], items[1], double.Parse(items[2]), double.Parse(items[3]), items[4]);
				listOfPets.Add(myPet);
			}
			Console.WriteLine($"Load complete. {fileName} has {listOfPets.Count} data entries");
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
}

void SaveMemoryValuesToFile(List<Pet> listOfPets)
{
	//string fileName = Prompt("Enter file name including .csv or .txt: ");
	string fileName = "regout.csv";
	string filePath = $"./data/{fileName}";
	string[] csvLines = new string[listOfPets.Count];
	for (int i = 0; i < listOfPets.Count; i++)
	{
		csvLines[i] = listOfPets[i].ToString();
	}
	File.WriteAllLines(filePath, csvLines);
	Console.WriteLine($"Save complete. {fileName} has {listOfPets.Count} entries.");
}