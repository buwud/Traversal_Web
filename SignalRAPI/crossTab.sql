select * from "Visitors"

select * from crossTab 
(
	'
	select "dateTime","ecity","cityVisitorCount"
	from "Visitors"
	order by 1,2
	'
) as ct("dateTime" timestamp, City1 int, City2 int, City3 int, City4 int, City5 int);

