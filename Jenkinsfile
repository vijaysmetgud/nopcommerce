pipeline {
    agent any

    environment {
        // Define environment variables
        DOTNET_VERSION = '8.0.112'    // Example .NET SDK version
        DOCKER_IMAGE_NAME = 'vsmetgud/dotnet'  // Your desired Docker image name
        DOCKER_REGISTRY = 'docker.io'        // Docker Hub (use your registry if not Docker Hub)
        DOCKER_CREDENTIALS = 'docker-hub-credentials' // Jenkins Docker Hub credentials ID
    }

    stages {
        stage('Checkout') {
            steps {
                // Checkout the code from Git repository
                checkout scm
            }
        }

        stage('Install .NET SDK') {
            steps {
                script {
                    // Install the required .NET SDK if necessary
                    sh 'wget https://download.visualstudio.microsoft.com/download/pr/1b8ccff0-3dff-4be3-a43d-6a953ec5e63a/4365d5e3f79d5456bb084c5c72e38f0f/dotnet-sdk-8.0.112-linux-x64.tar.gz'
                    sh 'sudo mkdir -p /usr/share/dotnet'
                    sh 'sudo tar -zxf dotnet-sdk-8.0.112-linux-x64.tar.gz -C /usr/share/dotnet'
                    sh 'sudo ln -s /usr/share/dotnet/dotnet /usr/local/bin/dotnet'
                }
            }
        }

        stage('Restore Dependencies') {
            steps {
                // Restore NuGet dependencies
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                // Build the project in Release mode
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                // Publish the project (output to a folder named "publish")
                sh 'dotnet publish --configuration Release --output ./publish'
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    // Create Docker image using Dockerfile in the current directory
                    // Make sure to modify your Dockerfile if needed (e.g., set WORKDIR, etc.)
                    docker.build(DOCKER_IMAGE_NAME, './Dockerfile')
                }
            }
        }

        stage('Push Docker Image to Registry') {
            steps {
                script {
                    // Push the Docker image to the Docker registry (Docker Hub in this example)
                    withCredentials([usernamePassword(credentialsId: DOCKER_CREDENTIALS, usernameVariable: 'DOCKER_USER', passwordVariable: 'DOCKER_PASSWORD')]) {
                        sh "echo $DOCKER_PASSWORD | docker login -u $DOCKER_USER --password-stdin $DOCKER_REGISTRY"
                        sh "docker push $DOCKER_REGISTRY/$DOCKER_IMAGE_NAME:latest"
                    }
                }
            }
        }
    }

    post {
        success {
            // Notify upon success
            echo 'Build and Dockerization were successful!'
        }
        failure {
            // Notify upon failure
            echo 'Build or Dockerization failed. Please check the logs for errors.'
        }
        always {
            // Clean workspace after build
            cleanWs()
        }
    }
}
