use Assignment1

--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details
begin
declare @salary int,@hra int,@da int,@it int,@deductions int,@GrossSalary int,@NetSalary int,@pf int
set @salary=10000
set @hra=0.1*@salary
set @da=0.2*@salary
set @pf=0.8*@salary
set @it=0.5*@salary
set @deductions=@pf-@it
if @pf<@it
	begin 
		print 'Not Possible'
	 end
set @GrossSalary=@hra+@da
set @NetSalary=@GrossSalary-@deductions
print 'Pay Slip :'
    print 'HRA: ' + cast(@hra as varchar(10)) + 
          ' DA: ' + cast(@da as varchar(10)) + 
          ' PF: ' + cast(@pf as varchar(10)) + 
          ' IT: ' + cast(@it as varchar(10)) + 
          ' Deductions: ' + cast(@deductions as varchar(10)) + 
          ' GrossSalary: ' + cast(@grosssalary as varchar(10)) + 
          ' NetSalary: ' + cast(@netsalary as varchar(10));
end


--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 


create table holiday (
    holiday_date date,
    holiday_name varchar(50)
)

insert into holiday values 
('2025-08-15', 'Independence Day'),
('2025-10-21', 'Diwali'),
('2025-01-26', 'Republic Day'),
('2025-12-25', 'Christmas')


create table emp1 (
    emp_id int,
    emp_name varchar(50),
    salary int
)

create or alter trigger holidays
on emp1
after insert,update,delete
as

begin
    declare @today date ='2025-12-25'--cast(getdate() as date); or '2025-12-25'
    declare @holiday_name varchar(50);

    select @holiday_name = holiday_name 
    from holiday 
    where holiday_date = @today;

    if @holiday_name is not null
    begin
        
         raiserror('Due to %s, you cannot manipulate data', 16, 1, @holiday_name)
		 rollback;
    end
end

insert into emp1 values(2,'Manohar',10000)






