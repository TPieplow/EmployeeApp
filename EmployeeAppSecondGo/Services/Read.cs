using EmployeeAppSecondGo.Interfaces;
using EmployeeAppSecondGo.Models;
using System.Text.Json;

namespace EmployeeAppSecondGo.Services;

public class Read
{
    internal void ToFile(string fileName, List<IEmployee> employeeList)
    {
        Console.WriteLine("Do you want to create a [1] - .txt or [2] - .json file?");
        string textChoice = Console.ReadLine()!;

        string filePath = Path.Combine(@"C:\EC\csharp\EmployeeAppSecondGo\ListFile", fileName);

        switch (textChoice)
        {
            case "1":
                try
                {
                    filePath = Path.ChangeExtension(filePath, ".txt");

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (IEmployee employee in employeeList)
                        {
                            string employeeInfo = $"{employee.Name},{employee.Position},{employee.Id}";
                            Console.WriteLine(employeeInfo);
                            writer.WriteLine(employeeInfo);
                        }
                        Console.WriteLine($"File {fileName}.txt created successfully.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured: {ex.Message}");
                }
                break;

            case "2":
                filePath = Path.ChangeExtension(filePath, ".json");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    string jsonData = JsonSerializer.Serialize(employeeList);
                    Console.WriteLine($"{jsonData}");
                    writer.Write(jsonData);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                break;

            default:
                Console.WriteLine("Not a valid option");
                break;
        }
    }

    internal void FromFile(List<IEmployee> employeeList)
    {
        string folderPath = Path.Combine(@"C:\EC\csharp\EmployeeAppSecondGo\ListFile");
        string[] files = Directory.GetFiles(folderPath);

        Console.Clear();
        Console.WriteLine("Available files in the folder: ");
        Console.WriteLine("*******************************");
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
        Console.WriteLine("*******************************");

        Console.Write("Enter the file you want to open (use proper file extension, json/txt/csv): ");
        string fileToRead = Console.ReadLine()!;

        string filePath = Path.Combine(@"C:\EC\csharp\EmployeeAppSecondGo\ListFile", fileToRead);
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine()!;
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] employeeInfo = line.Split(',');

                            if (employeeInfo.Length == 3)
                            {
                                string name = employeeInfo[0];
                                string position = employeeInfo[1];
                                Guid id = Guid.Parse(employeeInfo[2]);

                                IEmployee employee = new Employee(id, name, position);
                                employeeList.Add(employee);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid data format in the file.");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                DisplayMessage.Message($"Successfully loaded data from {fileToRead}");
            }
            else
            {
                Console.WriteLine($"File {fileToRead} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }

    internal void DeleteFile()
    {
        string folderPath = Path.Combine(@"C:\EC\csharp\EmployeeAppSecondGo\ListFile");
        string[] files = Directory.GetFiles(folderPath);

        Console.Clear();
        Console.WriteLine("Available files in the folder: ");
        Console.WriteLine("*******************************");
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
        Console.WriteLine("*******************************");

        Console.Write("Enter the name of the file you want to delete: ");
        string nameOfFileToDelete = Console.ReadLine()!;

        string fileToDelete = Path.Combine(folderPath, nameOfFileToDelete);

        try
        {
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
                DisplayMessage.Message($"File '{fileToDelete}' was successfully deleted.");
            }
            else
            {
                Console.WriteLine($"File {fileToDelete} not found.");
            }
        }catch (Exception ex) 
        { 
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
}
