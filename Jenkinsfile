pipeline{
  agent { label 'jdk' }
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
    stage('archieve'){
      steps{
        archive '**/nopCommerce.zip' 
        echo "Hello Jenkins and sad not good good"
      }
    }
  }
}

