pipeline{
  agent any
  stages{
    stage('vcs'){
      steps{
        git url: 'https://github.com/vijaysmetgud/nopcommerce.git', branch: 'master'
      }
    }
    stage('build'){
      steps{
        sh 'dotnet restore src/NopCommerce.sln'
        sh 'dotnet build -c Release src/NopCommerce.sln'
        
      }
    }
    stage('archieve'){
      steps{
        archive '**/nopCommerce.zip' 
      }
    }
  }
}
