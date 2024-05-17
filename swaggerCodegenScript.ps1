if(Test-Path ./swagger.json){
	Remove-Item ./swagger.json -Force
}

if(!(Test-Path ./SwaggerGeneratedFiles)){
	New-Item -Path "./SwaggerGeneratedFiles" -ItemType Directory
}

Invoke-WebRequest https://localhost:7056/swagger/v1/swagger.json -OutFile ./swagger.json


Remove-Item ./SwaggerGeneratedFiles/* -Recurse -Force

java -jar swagger-codegen-cli-3.0.50.jar generate -i swagger.json -l typescript-angular -o SwaggerGeneratedFiles

Remove-Item ./frontend/src/app/api/* -Recurse -Force
Copy-Item -Path ./SwaggerGeneratedFiles/* -Destination ./frontend/src/app/api -Recurse -Verbose


Read-Host -Prompt "Press Enter to exit"