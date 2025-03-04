param location string = resourceGroup().location

var unique = uniqueString(resourceGroup().id)

module apiService 'modules/compute/appservice.bicep' = {
  name: 'apiDeployment'
  params: {
    appName: 'api-${unique}'
    appServicePlanName: 'plan-api-${unique}'
    location: location
  }
}
