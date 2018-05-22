SELECT Login.[Last Name] AS Users, Resources.Resource
FROM Login
Inner join Many2Many
ON Login.[Login ID] = Many2Many.[Login ID]
Inner Join Resources
ON Many2Many.[Resource ID] = Resources.[Resource ID];