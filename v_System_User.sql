CREATE VIEW [dbo].[v_System_User]
AS
select 1 as ID, 
		SYSTEM_USER as [SYSTEM_USER], 
		CURRENT_USER as [CURRENT_USER]