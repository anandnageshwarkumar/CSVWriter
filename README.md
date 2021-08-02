# Implement CSV writer, Retrieve properties from a class and print it to CSV. Properties can be reference or value types. If a class has nested properties then hierarchy limit can be set to a maximum of 1000

1) ListExtensions.cs will be able to accept the collection of value types or reference types and print to csv.
2) The allowed value types and reference types are defined in TypeChecker.cs
3) csv file will be overwritten for each operation, please delete the file from temp before running the sln second time.
4) ListExtensions.cs has an optional parameter hierarchyLimit, which limits the maximum child level of a parent class to be printed, by default  hierarchyLimit  = 1000
5) if a class has a child class and so on.. all this properties are flattened, are printed in the order the same way as class structure.
6) TestDataSets.cs has the sample data to test all features of   ListExtensions.cs



