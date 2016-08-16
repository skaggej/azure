#Login-AzureRmAccount
#Get-AzureRmSubscription
Select-AzureRmSubscription -SubscriptionName 'FUSE (MSDN)'
New-AzureRmResourceGroup -Name Bacon123 -Location 'West US'

$deployment = @{
	Name='BaconDeployment';
	ResourceGroupName = 'Bacon123';
	Mode='Complete';
	TemplateFile = "$PSScriptRoot\AzureDeploy.json";
	TemplateParameterObject = @{
		adminUsername = 'fuse.admin';
		adminPassword = 'C@t@pult1!';
		dnsLabelPrefix = 'baconfuse123';
	}
}

New-AzureRmResourceGroupDeployment @deployment