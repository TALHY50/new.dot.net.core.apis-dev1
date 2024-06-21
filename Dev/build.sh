sudo rsync -avzh --progress "dev/" "/root/new.dot.net.core.apis"
 
app="new.dot.net.core.apis/IMT/src/IMT.Web/"
rdir="root"
#cd /$rdir/$app
sudo pkill dotnet
sudo nohup dotnet run --project /$rdir/$app/IMT.Web.csproj
#sudo dotnet run
