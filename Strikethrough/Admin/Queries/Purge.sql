select * from aspnet_users
select * from aspnet_membership
select * from aspnet_usersinroles
select * from user_canvas
select * from user_usersingroups
select * from user_groups

select * from user_userhasteachers

delete from aspnet_membership
where userid != '9AB7BB44-D17E-4972-A325-3FC442828B82'
and userid != 'E0760C6A-E2EB-430D-9A68-88D8EAAB26E0'

delete from aspnet_usersinroles
where userid != '9AB7BB44-D17E-4972-A325-3FC442828B82'
and userid != 'E0760C6A-E2EB-430D-9A68-88D8EAAB26E0'

delete from user_canvas
where userid != '9AB7BB44-D17E-4972-A325-3FC442828B82'
and userid != 'E0760C6A-E2EB-430D-9A68-88D8EAAB26E0'

delete from user_usersingroups
where userid != '9AB7BB44-D17E-4972-A325-3FC442828B82'
and userid != 'E0760C6A-E2EB-430D-9A68-88D8EAAB26E0'

delete from user_groups
where teacherid != '9AB7BB44-D17E-4972-A325-3FC442828B82'
and teacherid != 'E0760C6A-E2EB-430D-9A68-88D8EAAB26E0'

delete from aspnet_users
where userid != '9AB7BB44-D17E-4972-A325-3FC442828B82'
and userid != 'E0760C6A-E2EB-430D-9A68-88D8EAAB26E0'