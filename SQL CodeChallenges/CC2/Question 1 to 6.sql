use CodeChallenge

--Write a query to display your birthday( day of week)

select datename(weekday, '2004-06-23') AS MyBirthDay















--2.	Write a query to display your age in days


select DATEDIFF(DAY, '2004-06-23', GETDATE()) as 'My Age in Days';











--3.	Write a query to display all employees information those who joined before 5 years in the current month
--(Hint : If required update some HireDates in your EMP table of the assignment)
use Assignment1

select * from emp

update emp set hire_date='2019-07-01' where empno=7369
update emp set hire_date='2019-07-05' where empno=7499
update emp set hire_date='2019-07-10' where empno=7521
update emp set hire_date='2019-07-15' where empno=7566
update emp set hire_date='2019-07-20' where empno=7654

select * from emp where DATEDIFF(YEAR, '2004-06-23', getdate())>=5 and MONTH(hire_date)=MONTH(getdate())




--4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
--	a. First insert 3 rows 
--	b. Update the second row sal with 15% increment  
--        c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.
--a
insert into emp values(1,'Manohar','SDE',7839,'2025-06-15',100000,300,20),
(2,'Dinesh','Data Scientist',7839,'2025-06-12',34566,200,20),
(3,'Jaya','SDE2',7839,'2025-06-11',8765,200,30)
--b 

update emp set salary = salary+(salary * 1.15) where empno=2

select* from emp






-- c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.


select * into #TempEmployee FROM emp WHERE empno = 1


delete from emp where empno = 1
select * from emp

insert into Emp select * from #TempEmployee

select * from dept



--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus
 
create function calculate_bonus(@deptno int, @sal int)
returns int
as
begin
    declare @bonus int

    if @deptno = 10
        set @bonus = 0.15 * @sal
    else if @deptno = 20
        set @bonus = 0.20 * @sal
    else
        set @bonus = 0.05 * @sal

    return @bonus
end


select empno, ename, salary, deptno,
       dbo.calculate_bonus(deptno, salary) as 'Bonus'
from emp;






--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
select * from emp
select * from dept

create or alter proc update_sal
as 
begin

update emp
set salary = salary + 500
where deptno in (
    select deptno from dept where dname = 'sales'
)
and salary < 1500
end 
exec  update_sal
select * from emp















