pipeline{
  agent any
stages{
    stage('vcs'){
      steps{
        git branch: 'master', url: 'https://github.com/vijaysmetgud/nopcommerce.git'
      }
    }
    stage('build'){
      steps{
        sh 'dotnet restore src/NopCommerce.sln'
        sh 'dotnet build -c Release src/NopCommerce.sln'
        
      }
    }
    stage('Sonarqube Analysis'){
      steps{
        sh '''
            dotnet tool install --global dotnet-sonarscanner
            dotnet sonarscanner begin /k:"nop-sonar" /d:sonar.host.url="http://18.119.138.43:9000" /d:sonar.login="cac6bebefd48614c71cae50821c05719d5a53db4"
            dotnet build
            dotnet sonarscanner end /d:sonar.login="cac6bebefd48614c71cae50821c05719d5a53db4"
        '''
      }    
    }
    stage('archieve'){
      steps{
        archive '**/nopCommerce.zip' 
        echo "Package is created"
      }
    }
  }
}

