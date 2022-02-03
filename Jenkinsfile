
//def ReleaseDir = "c:\inetpub\wwwroot"
pipeline {
			agent any
			stages {
				stage('Source'){
					steps{
						checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[credentialsId: 'fbc85ed5-5106-4fb7-8515-2f51094f586b', url: 'https://github.com/sshannon237/Assignment3.git']]])
					}
				}
				stage('Build') {
    					steps {

    					    bat "\"${tool 'MSBuild'}\" Assignment3.sln /t:restore /p:RestorePackagesConfig=true /p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:SkipInvalidConfigurations=true /t:build /p:Configuration=Release /p:Platform=\"Any CPU\" /p:DeleteExistingFiles=True /p:publishUrl=c:\\inetpub\\wwwroot"
    					}
				}
			}
}