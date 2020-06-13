## 1.先下载Consul

## 2.运行Agent
consul agent -dev
打开localhost:8500 查看consul的UI界面

## 3.启动服务
dotnet ApiServiceA.dll --urls="http://*:2021" --ip="127.0.0.1" --port=2021
dotnet ApiServiceB.dll --urls="http://*:3021" --ip="127.0.0.1" --port=3021
dotnet ApigatewayCenter.dll --urls="http://*:5916" --ip="127.0.0.1" --port=5916

## 4.注意
(1)http://localhost:5916/swagger/index.html  swagger访问地址需要加上swagger
(2)consoul版本和ocelet版本对应 不然会路由不到  之前用的consul 1.6就不行 还原成0.7之后才可以了 



