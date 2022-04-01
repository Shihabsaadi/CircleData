// See https://aka.ms/new-console-template for more information
using CircleData;
using System.Dynamic;

var employees = new List<Employee>
{
    new Employee {Id=1,Name="Alice"},
    new Employee {Id=2,Name="John"},
    new Employee {Id=3,Name="Jane"},
    new Employee {Id=4,Name="Alice"},
    new Employee {Id=5,Name="Bob"},
};


var files = new List<CircleData.File>
{
    new CircleData.File {Name="100",Type="jpeg"},
    new CircleData.File {Name="Alice",Type="png"},
    new CircleData.File {Name="3",Type="jpg"},
    new CircleData.File {Name="1",Type="jpg"},
    new CircleData.File {Name="John",Type="jpeg"},
};
var dynamic = new List<dynamic>();
dynamic row = new ExpandoObject();
var results = new List<ResultView>();
foreach (var emp in employees)
{
    var byId = files.Where(x => x.Name.Equals(emp.Id.ToString())).FirstOrDefault();
    var byName = files.Where(x => x.Name.Equals(emp.Name.ToString())).FirstOrDefault();
    var file = byId == null ? byName : byId;
    if (file != null)
    {
        if (results.Count != 0)
        {
            var byFileType = results.Where(x => x.FileType.Equals(file.Type)).FirstOrDefault();
            if (byFileType != null)
            {
                results.Add(new ResultView { EmployeeId = emp.Id, FileType = file.Type, Reason = "Matches "+ file.Name +"."+file.Type+ " but jpg already recorded"});
            }
            else
            {
                results.Add(new ResultView { EmployeeId = emp.Id, FileType = file.Type, Reason = "Matches " + file.Name + "." + file.Type });
            }
        }
        else
            results.Add(new ResultView { EmployeeId = emp.Id, FileType = file.Type, Reason = "Matches " + file.Name + "." + file.Type });
    }
    else
    {
        results.Add(new ResultView { EmployeeId = emp.Id, FileType = "-", Reason = "No Match" });
    }
}
foreach (var result in results)
{
    Console.WriteLine("EmployeeId: " + result.EmployeeId+ " " + " Name: " + result.FileType + " " + " Reason: " + result.Reason);
}
//Console.WriteLine(employees);
