sudo rsync -avzh --progress "dev/" "/var/www/html/new.dot.net.core.apis"

sudo cd /var/www/html/new.dot.net.core.apis/IMT/src/IMT.Web && sudo /usr/bin/dotnet build IMT.Web.csproj

sudo systemctl restart IMTWeb.service
