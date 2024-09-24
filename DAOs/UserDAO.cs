using OfficeOpenXml;
using UserData.Models;

namespace UserData.DAOs {
    public class UserDAO : IUserDAO {
        private readonly string _filePath = "D:\\ArshNirmal\\Training\\DotNet\\UserData\\Data\\UserData.xlsx";
        public List<Person> ReadData() {
            var data = new List<Person>();
            var package = new ExcelPackage(new FileInfo(_filePath));

            try {
                using(package) {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for(int row = 2; row <= rowCount; row++) {
                        var person = new Person {
                            Name = worksheet.Cells[row, 2].Text,
                            DateOfBirth = worksheet.Cells[row, 3].Text,
                            ResidentialAddress = worksheet.Cells[row, 4].Text,
                            PermanentAddress = worksheet.Cells[row, 5].Text,
                            PhoneNumber = worksheet.Cells[row, 6].Text,
                            Email = worksheet.Cells[row, 7].Text,
                            MaritalStatus = worksheet.Cells[row, 8].Text,
                            Gender = worksheet.Cells[row, 9].Text,
                            Occupation = worksheet.Cells[row, 10].Text,
                            AadharCardNumber = worksheet.Cells[row, 11].Text,
                            PANNumber = worksheet.Cells[row, 12].Text,
                            ImageFilePath = worksheet.Cells[row, 13].Text
                        };

                        data.Add(person);
                    }
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                package.Dispose();
            }

            return data;
        }

        public Person? ReadData(int id) {
            var package = new ExcelPackage(new FileInfo(_filePath));

            try {
                using(package) {
                    var worksheet = package.Workbook.Worksheets[0];
                    int row = id + 1;

                    var person = new Person {
                        Name = worksheet.Cells[row, 2].Text,
                        DateOfBirth = worksheet.Cells[row, 3].Text,
                        ResidentialAddress = worksheet.Cells[row, 4].Text,
                        PermanentAddress = worksheet.Cells[row, 5].Text,
                        PhoneNumber = worksheet.Cells[row, 6].Text,
                        Email = worksheet.Cells[row, 7].Text,
                        MaritalStatus = worksheet.Cells[row, 8].Text,
                        Gender = worksheet.Cells[row, 9].Text,
                        Occupation = worksheet.Cells[row, 10].Text,
                        AadharCardNumber = worksheet.Cells[row, 11].Text,
                        PANNumber = worksheet.Cells[row, 12].Text,
                        ImageFilePath = worksheet.Cells[row, 13].Text
                    };

                    return person;
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                package.Dispose();
            }
            return null;
        }

        public Person? AppendData(Person person) {
            if(!File.Exists(_filePath)) {
                throw new FileNotFoundException("The Excel file was not found.", _filePath);
            }

            var package = new ExcelPackage(new FileInfo(_filePath));

            try {
                using(package) {
                    var worksheet = package.Workbook.Worksheets[0] ?? throw new InvalidOperationException("Worksheet not found.");
                    int rowCount = worksheet.Dimension?.Rows ?? 0;

                    if(rowCount == 0) {
                        throw new InvalidOperationException("Worksheet is empty.");
                    }

                    int newRow = rowCount + 1;


                    worksheet.Cells[newRow, 1].Value = newRow - 1;
                    worksheet.Cells[newRow, 2].Value = person.Name;
                    worksheet.Cells[newRow, 3].Value = person.DateOfBirth;
                    worksheet.Cells[newRow, 4].Value = person.ResidentialAddress;
                    worksheet.Cells[newRow, 5].Value = person.PermanentAddress;
                    worksheet.Cells[newRow, 6].Value = person.PhoneNumber;
                    worksheet.Cells[newRow, 7].Value = person.Email;
                    worksheet.Cells[newRow, 8].Value = person.MaritalStatus;
                    worksheet.Cells[newRow, 9].Value = person.Gender;
                    worksheet.Cells[newRow, 10].Value = person.Occupation;
                    worksheet.Cells[newRow, 11].Value = person.AadharCardNumber;
                    worksheet.Cells[newRow, 12].Value = person.PANNumber;
                    worksheet.Cells[newRow, 13].Value = person.ImageFilePath;

                    package.Save();

                    return ReadData(newRow - 1);
                }
            } catch(FileNotFoundException ex) {
                Console.WriteLine($"File not found: {ex.Message}");
            } catch(InvalidOperationException ex) {
                Console.WriteLine($"Invalid operation: {ex.Message}");
            } catch(Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
            } finally {
                package.Dispose();
            }
        }

        public Person? UpdateData(int id, Person person) {
            if(person == null) {
                return null;
            }

            var package = new ExcelPackage(new FileInfo(_filePath));

            try {
                using(package) {
                    var worksheet = package.Workbook.Worksheets[0];
                    int row = id + 1;

                    worksheet.Cells[row, 2].Value = person.Name;
                    worksheet.Cells[row, 3].Value = person.DateOfBirth;
                    worksheet.Cells[row, 4].Value = person.ResidentialAddress;
                    worksheet.Cells[row, 5].Value = person.PermanentAddress;
                    worksheet.Cells[row, 6].Value = person.PhoneNumber;
                    worksheet.Cells[row, 7].Value = person.Email;
                    worksheet.Cells[row, 8].Value = person.MaritalStatus;
                    worksheet.Cells[row, 9].Value = person.Gender;
                    worksheet.Cells[row, 10].Value = person.Occupation;
                    worksheet.Cells[row, 11].Value = person.AadharCardNumber;
                    worksheet.Cells[row, 12].Value = person.PANNumber;
                    worksheet.Cells[row, 13].Value = person.ImageFilePath;
                }

                package.Save();

                return ReadData(id);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                package.Dispose();
            }
            return null;
        }
    }
}