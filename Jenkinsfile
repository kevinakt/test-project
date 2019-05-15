pipeline {
  agent any
  stages {
    stage('test') {
      environment {
        PARAM = 'two'
      }
      steps {
        build 'test_param'
      }
    }
  }
}