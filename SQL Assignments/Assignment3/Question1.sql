use Assignment1

select * from emp  --empno,ename,job,mgr_id,hire_date,salary,comm,deptno from dept DEPT(deptno, dname, loc) 
select * from dept
--1. Retrieve a list of MANAGERS. 
	select e.ename from emp e join emp m 
	on m.mgr_id=e.empno
--2. Find out the names and salaries of all employees earning more than 1000 per month. 
	select ename,salary from emp where salary>1000
--3. Display the names and salaries of all employees except JAMES. 
	select ename,salary from emp where ename!='James'
--4. Find out the details of employees whose names begin with ‘S’. 
	select * from emp where ename like 's%'
--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
	select * from emp where ename like '%a%'
--6. Find out the names of all employees that have ‘L’ as their third character in their name. 
	select * from emp where ename like '__L%'
--7. Compute daily salary of JONES. 
	select (salary)/30 as 'Daily wages' from emp where ename='jones'
--8. Calculate the total monthly salary of all employees. 
	select sum(salary) as 'Sum of salaries' from emp
--9. Print the average annual salary . 
	select avg(salary) as 'Avg of salaries' from emp
--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
	select ename,job,salary,deptno from emp where not (job='salesman' and deptno=30)
--11. List unique departments of the EMP table. 
	select job,count(*) as DifferentJobs from emp
	group by(job)
--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30.
--Label the columns Employee and Monthly Salary respectively.
	select ename as Employee,salary 'Monthly Salary' from emp
	where salary>1500 and deptno in (10,30)
--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 
	select ename,job,salary from emp where (job='Manager' or job='Analyst') and salary not in (1000,3000,5000)
--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
	select ename,salary,comm from emp where comm>(salary+(salary*0.1))
--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
	select ename from emp where ename like '%L%L%'and(deptno=30 or mgr_id=7782)
--16. Display the names of employees with experience of over 30 years and under 40 yrs.
	--Count the total number of employees. 
	select ename as 'names' from emp where 
    (YEAR(GETDATE()) - YEAR(hire_date)) BETWEEN 31 AND 39;
--17. Retrieve the names of departments in ascending order and their employees in descending order. 
	
	select d.dname as Department, e.ename as Employee from dept d
	join emp e on d.deptno = e.deptno
	order by d.dname asc, e.ename desc;
--18. Find out experience of MILLER. 
	select (YEAR(GETDATE()) - YEAR(hire_date)) as 'Experience' from emp where ename='Miller'





	

	
