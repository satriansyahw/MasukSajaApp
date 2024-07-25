# MSSQL SCRIPT
### 1.Ensure you have installed Mssql server and or have access to mssql server and database
### 2.There 2 Stored Procedure(SP) sql files 
#### 2.1 dbo_ChangeBitValueV1.sql > using ~ Not operator to change value from 0 to 1 and 1 to 0
#### 2.1 dbo_ChangeBitValueV2.sql > using Case ... When operation to change value from 0 to 1 and 1 to 0
### 3.Open Sql Server Management Studio (SSMS) and execute sql script in your database
### 4. On SSMS IDE, click ribbon New Query and insert this initial data , note we use temporary table with name "#TEST2", if we change the name must change implementation in SP files
CREATE TABLE #TEST2 ([Id] INT, [A] BIT, [B] BIT, [C] BIT, [D] BIT, [E] BIT)
INSERT INTO #TEST2 ([Id], [A], [C], [E]) VALUES (1, 'true', 'false', 'true')
INSERT INTO #TEST2 ([Id], [A], [B], [C]) VALUES (2, 'true', 'true', 'true')
INSERT INTO #TEST2 ([Id], [C], [D], [E]) VALUES (1, 'false', 'false', 'true')
### 5. Clear sql script from the window query
### Try to run this script 
Select * from #TEST2
EXEC dbo.ChangeBitValueV2 @Id = 1, @Column = 'B'
EXEC dbo.ChangeBitValueV2 @Id = 2, @Column = 'A'
Select * from #TEST2
### Result : We can see the result in the second table, column B with id 1 still remain Null and column A with id 2 the value changed from 1 to 0
![image](https://github.com/user-attachments/assets/22104835-5e01-43a8-b389-ee9be32c47af)

 
