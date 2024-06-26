sudo rm -rf /var/www/html/new.dot.net.core.apis/

sudo rsync -avzh --progress "dev/" "/var/www/html/new.dot.net.core.apis"

sudo /usr/bin/dotnet build /var/www/html/new.dot.net.core.apis/IMT/src/IMT.Web/IMT.Web.csproj

sudo systemctl restart IMTWeb.service
