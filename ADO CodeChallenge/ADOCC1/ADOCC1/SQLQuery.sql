
CREATE TABLE Employee_Details (
    EmpId int identity(1,1)  primary key,
    name varchar(100),
    Salary int,
	cal_salary int,
    Gender varchar(100)
)

select * from Employee_Details

create or alter procedure insert_employee
    @name varchar(100),
    @salary int,
    @gender varchar(100)
as
begin
    declare @cal_salary int;

    set @cal_salary = @salary - (@salary * 0.10);

    insert into employee_details (name, salary, cal_salary, gender)
    output inserted.empid, inserted.cal_salary
    values (@name, @salary, @cal_salary, @gender);
end


exec insert_employee @name = 'saisatya', @salary = 50000, @gender = 'male'


--Query2


create or alter procedure update_salary_by_100
    @empid int
as
begin
  
    update employee_details
    set salary = salary + 100
    where empid = @empid;
end

exec update_salary_by_100 @empid=1















