-- CREATE DATABASE
--create database AccDeficit

--use Master
--use AccDeficit

-- CREATE TABLES
create table Signin(
	signinID int identity(1, 1) primary key,
	userName nvarchar(max),
	userPassword nvarchar(max)
)

create table Customers(
	customerID int identity(1, 1) primary key,
	cFirstName nvarchar(max),
	cLastName nvarchar(max),
	phone nvarchar(max),
	addressLine nvarchar(max),
	addDate date
)

create table Cate(
	cateID int identity(1, 1) primary key,
	cateName nvarchar(max),
	explanation nvarchar(max),
	addDate date
)

create table Products(
	productID int identity(1, 1) primary key,
	proName nvarchar(max),
	prePrice float,
	salePrice float,
	quantity int,
	addDate date,
	cateID int Foreign key references Cate(cateID) on delete cascade
)

create table Orders(
	orderID int identity(1, 1) primary key,
	piece int,
	orderDate date,
	productID int Foreign key references Products(productID) on delete cascade,
	customerID int Foreign key references Customers(customerID) on delete cascade
)


-- INSERTS
insert into Signin (userName, userPassword) values ('admin', '1')

insert into Customers (cFirstName, cLastName, phone, addressLine, addDate) values ('Yusuf', 'Yazıcı', '(534) 152-4895', 'İstiklal Caddesi No:78/4 Bayrampaşa/İstanbul', '2019-09-21')
insert into Customers (cFirstName, cLastName, phone, addressLine, addDate) values ('Abdulkadir', 'Ömür', '(530) 264-5284', 'Kunduracılar Caddesi No:128/1 Beşikdüzü/Trabzon', '2019-09-21')
insert into Customers (cFirstName, cLastName, phone, addressLine, addDate) values ('Uğurcan', 'Çakır', '(532) 632-9878', 'Atatürk Caddesi No:74/10 Darıca/Kocaeli', '2019-09-21')
insert into Customers (cFirstName, cLastName, phone, addressLine, addDate) values ('Hüseyin', 'Türkmen', '(534) 644-1773', 'Hürriyet Caddesi No:146/8 Hendek/Adapazari', '2019-09-21')

--****************************************

insert into Cate (cateName, explanation, addDate) values ('Dizüstü Bilgisayar', 'Bilgisayar/Tablet', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Tablet', 'Bilgisayar/Tablet', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Masaüstü Bilgisayar', 'Bilgisayar/Tablet', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Veri Depolama', 'Bilgisayar/Tablet', '2019-09-21')
				  					
insert into Cate (cateName, explanation, addDate) values ('Cep Telefonu', 'Telefon & Telefon Aksesuarları', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Akıllı Saat ve Bileklikler', 'Telefon & Telefon Aksesuarları', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Powerbank & Bluetooth Kulaklık', 'Telefon & Telefon Aksesuarları', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Kılıf ve Ekran Koruyucular', 'Telefon & Telefon Aksesuarları', '2019-09-21')
				  					
insert into Cate (cateName, explanation, addDate) values ('Televizyon', 'TV, Görüntü & Ses Sistemleri', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Müzik Sistemleri', 'TV, Görüntü & Ses Sistemleri', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Blu-Ray ve DVD Oynatıcılar', 'TV, Görüntü & Ses Sistemleri', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Kablo & Soketler', 'TV, Görüntü & Ses Sistemleri', '2019-09-21')
				  					   
insert into Cate (cateName, explanation, addDate) values ('Çamaşır Makineleri', 'Beyaz Eşya', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Buzdolapları', 'Beyaz Eşya', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Bulaşık Makineleri', 'Beyaz Eşya', '2019-09-21')
insert into Cate (cateName, explanation, addDate) values ('Derin Dondurucular', 'Beyaz Eşya', '2019-09-21')


insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Lenovo Ideapad S145-14IWL', 2750, 3500, 40, '2019-09-21', 1)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Dell Gaming G315', 1850, 2500, 40, '2019-09-21', 1)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('HP 15-RA012NT', 1300, 1750, 40, '2019-09-21', 1)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Acer Nitro AN515-52', 1400, 2000, 40, '2019-09-21', 1)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Asus ROG FX504GE-E4777', 2950, 3750, 40, '2019-09-21', 1)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Casper Nirvana F650.8550-8E55X-G-F', 1150, 1500, 40, '2019-09-21', 1)
								  						
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Lenovo Tab E10 TB-X104F 32GB 10.1', 490, 750, 40, '2019-09-21', 2)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung Galaxy Tab 3 Lite T113 8GB 7', 590, 800, 40, '2019-09-21', 2)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Apple iPad 6.Nesil 32GB 9.7 Wi-Fi IPS', 1050, 1400, 40, '2019-09-21', 2)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Alcatel Pixi 4 8GB 7', 950, 1450, 40, '2019-09-21', 2)
									  					
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('TURBOX ATM900012 Intel i5m 4GB Ram 320GB Hdd', 1650, 2250, 40, '2019-09-21', 3)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('HP 460-P202NT Intel Core i3 7100T 4GB 1TB Windows 10 Home', 1250, 1750, 40, '2019-09-21', 3)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Izoly N13PF i5-3470 16GB 1TB GTX1050Tİ 4GB 21.5', 1870, 2400, 40, '2019-09-21', 3)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('HP Omen 875-0008NT Intel Core i5 8400 8GB 1TB + 128GB SSD GTX1050Ti', 1350, 2000, 40, '2019-09-21', 3)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Casper N1H.7400-4T05X Intel Core i5 7400 4GB 1TB Freedos', 1270, 1800, 40, '2019-09-21', 3)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('MSI TRIDENT 3 7RB-252XTR Intel Core i7 7700 4GB 1TB + 128GB SSD GTX1050Ti', 3150, 3700, 40, '2019-09-21', 3)
									  						
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('SanDisk Cruzer Blade 32GB', 28, 45, 40, '2019-09-21', 4)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung 860 Evo 250GB 560MB-520MB/s Sata3 2.5', 90, 150, 40, '2019-09-21', 4)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Toshiba Canvio Basic 1TB 2.5', 225, 295, 40, '2019-09-21', 4)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Seagate Expansion 1TB 2.5 USB 3.0', 190, 245, 40, '2019-09-21', 4)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('HP S700 250GB 555/515MB/s Sata 3 2.5', 325, 400, 40, '2019-09-21', 4)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('WD My Passport 2TB 2.5 USB 3.0', 360, 450, 40, '2019-09-21', 4)
									  						 
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung Galaxy Note 10 Plus 256 GB', 8750, 11400, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Sony Xperia XA1 Ultra', 980, 1200, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Xiaomi Redmi Note 7 64 GB', 1150, 1758, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Huawei Mate 20 Lite 64 GB', 1350, 2080, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Alcatel 2003G', 195, 270, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Asus Zenfone Max Pro', 1100, 1490, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('LG V30 Plus 128 GB', 1890, 2570, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('General Mobile GM8 32 GB', 68, 100, 40, '2019-09-21', 5)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Apple iPhone XS Max 512 GB', 8800, 13800, 40, '2019-09-21', 5)
										  				
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Xiaomi Mi Band 4 Akıllı Bileklik', 145, 210, 40, '2019-09-21', 6)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Owwotech M3 Akıllı Bileklik', 28, 43, 40, '2019-09-21', 6)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('A1 Smart Watch Universal', 72, 110, 40, '2019-09-21', 6)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Huawei Honor Band 4 Akıllı Bileklik', 165, 240, 40, '2019-09-21', 6)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung Galaxy Watch Active', 690, 1090, 40, '2019-09-21', 6)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Apple Watch Seri 4 44mm GPS', 2960, 3700, 40, '2019-09-21', 6)
										  				
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung Galaxy Buds (Beyaz)-SM-R170NZWATUR Sound By AKG', 705, 890, 40, '2019-09-21', 7)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Spigen Legato R53E Kablosuz Bluetooth Suya Dayanıklı Spor Kulaklık Black', 88, 150, 40, '2019-09-21', 7)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Apple AirPods 2. Nesil Bluetooth Kulaklık MV7N2TU/A', 650, 900, 40, '2019-09-21', 7)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Sennheiser Momentum True Wireless Kablosuz Kulak İçi Kulaklık', 1480, 1950, 40, '2019-09-21', 7)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Anker SoundBuds Mono BT Bluetooth Kulaklık-A3701-OFP', 145, 200, 40, '2019-09-21', 7)
										  				
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Case 4U Apple iPhone 7 Plus-8 Plus Kılıf Ultra İnce Silikon Füme', 7, 12, 40, '2019-09-21', 8)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Spigen Samsung Galaxy A50 Kılıf Rugged Armor Matte Black', 45, 70, 40, '2019-09-21', 8)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('KNY Samsung Galaxy A70 Kılıf 4 Köşe', 22, 35, 40, '2019-09-21', 8)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Deer Case Apple iPhone 7 Plus Silikon Kılıf Kauçuk', 32, 56, 40, '2019-09-21', 8)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Blueway Apple İphone 6-6S Ekran Koruyucu + Şeffaf Silikon', 19, 27, 40, '2019-09-21', 8)
								  							
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Vestel 65UD9000 65 164 Ekran Uydu Alıcılı 4K Ultra HD Smart LED TV', 3850, 4350, 40, '2019-09-21', 9)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung UE-40N5300 Full HD Uydu Alıcılı Smart LED', 1490, 2230, 40, '2019-09-21', 9)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Awox U3200STR 32 82 Ekran Uydu Alıcılı HD LED TV', 595, 720, 40, '2019-09-21', 9)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Philips 50PUS7303/62 50 126 Ekran Uydu Alıcılı 4K Ultra HD Smart LED TV', 3140, 3960, 40, '2019-09-21', 9)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Awox AWX-10943ST 43 109 Ekran Uydu Alıcılı Full HD LED TV', 850, 1195, 40, '2019-09-21', 9)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('LG 70UM7450 70 177 Ekran Uydu Alıcılı 4K Ultra HD Smart LED TV', 6245, 7300, 40, '2019-09-21', 9)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Regal 32R4020H 32 81 Ekran Uydu Alıcılı LED TV', 785, 940, 40, '2019-09-21', 9)
										  				
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Harman Kardon Soundstick Bluetooth Bağlantılı 2.1 Hoparlör Sistemi', 1160, 1650, 40, '2019-09-21', 10)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Bowers&Wilkins Zeppelin Wireless", "Philips BTM2660W/12 Bluetooth Micro', 2250, 3000, 40, '2019-09-21', 10)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Philips BTM2660W/12 Bluetooth Micro', 620, 700, 40, '2019-09-21', 10)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Marshall Stockwell Blueooth Hoparlör Siyah ZD.4091451', 1230, 1700, 40, '2019-09-21', 10)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Bose Soundtouch 10 Kablosuz Müzik Sistemi', 1370, 1765, 40, '2019-09-21', 10)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Sony Shake-33 2200W Bluetooth Yüksek Güçlü Ev Ses Sistemi', 3260, 4060, 40, '2019-09-21', 10)
								  						
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Sony DVP-SR760 USBli DVD Oynatıcı', 245, 310, 40, '2019-09-21', 11)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Kamosonic Ks-Dx-3802 Dvd Player Usb+Sd Hoparlörlü', 95, 150, 40, '2019-09-21', 11)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Premier PRD-990 DVD Oynatıcı', 115, 170, 40, '2019-09-21', 11)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Denon DVD 2500 BT Blu-ray Oynatıcı', 3340, 4060, 40, '2019-09-21', 11)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Goldmaster D-726 DVD Oynatıcı', 225, 300, 40, '2019-09-21', 11)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Cambridge Audio AZUR 851C CD Oynatıcı Gümüş', 8890, 11000, 40, '2019-09-21', 11)
									  					
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Philips SWV5401H 4K Destekli 1,8m Ethernet HDMI Kablo (ULTRA HD-3D)', 23, 35, 40, '2019-09-21', 12)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Paugge Hdmi 2.0b 4K 60Hz 18Gbps Bandwith HDR Dolby Vision', 61, 90, 40, '2019-09-21', 12)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Case 4U Premium 4K HDMI 2.0 Kablo - 60 HZ', 54, 70, 40, '2019-09-21', 12)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Spigen Essential C20CH USB-C / Type-C 3.1 to Hdmi USB Kablosu', 72, 100, 40, '2019-09-21', 12)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Qed Qe-0004 Supremus Hoparlör Kablosu 2X3 Metre', 5950, 7650, 40, '2019-09-21', 12)
								  						
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Vestfrost VF ÇM 5800 A++ 5 kg 800 Devir', 950, 1250, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung WW90J5475FW/AH A+++ 1400 Devir 9 kg', 1780, 2250, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Profilo CMG120DTR A+++ 9 Kg 1200 Devir', 1660, 2070, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Bosch WAT24480TR A+++ 9 kg 1200 Devir', 2150, 2470, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Hoover HL 14102D3R-S A+++ 10 Kg 1400', 1750, 2100, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Grundig GWM 9701 A+++ 7 kg 1000 Devir', 1260, 1540, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Siemens WM12T480TR A+++ 9 kg 1200', 2130, 2540, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Vestel CM 7610 A+++ 7 kg 1000 Devir', 1180, 1550, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Altus AL 7100 ML A+++ 7 kg 1000 Devir', 1090, 1480, 40, '2019-09-21', 13)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('LG FH0C9CDHK7.ASSPLTK A++ 17 kg Yıkama / 10 kg Kurutma 1100 Devir', 6970, 8150, 40, '2019-09-21', 13)
										  				
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Vestfrost VF 1268 A+ 300 lt Statik', 1240, 1600, 40, '2019-09-21', 14)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Vestel SC470 A+ 470 lt Statik', 1480, 1900, 40, '2019-09-21', 14)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Grundig GKNE 4800 A+ 475 lt No-Frost', 2150, 2600, 40, '2019-09-21', 14)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Samsung RT43K6000WW A+ 440 Lt Beyaz NoFrost', 2030, 2500, 40, '2019-09-21', 14)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Altus AL-306 E A+ 140 lt Statik Büro Tipi Mini Buzdolabı', 725, 940, 40, '2019-09-21', 14)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('LG GR-X31FTKHL.ASBPLTK A+ 889 lt No-Frost', 13440, 17350, 40, '2019-09-21', 14)
									  					
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Vestfrost VF BM 2003 A++ 3 Programlı', 890, 1140, 40, '2019-09-21', 15)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Altus AL 434 C A+ 4 Programlı', 995, 1230, 40, '2019-09-21', 15)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Bosch SMS44DI00T A+ 4 Programlı', 1670, 2000, 40, '2019-09-21', 15)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Siemens SN234I00DT iQ300 4 Programlı', 1490, 1870, 40, '2019-09-21', 15)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Profi̇lo BM4320EG 4 Programlı', 1160, 1570, 40, '2019-09-21', 15)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Regal Pratik BM 310 A++ 3 Programlı', 895, 1120, 40, '2019-09-21', 15)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Electrolux ESF7506ROX A+++ 9 Programlı', 5970, 7500, 40, '2019-09-21', 15)
						  									
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Grundig GFSE 6140 A+ 200 Lt.', 1640, 2000, 40, '2019-09-21', 16)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Vestel Cde-M1102W A+ 6 Çekmeçeli', 1070, 1300, 40, '2019-09-21', 16)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Profilo DF1133W3VV A++ Çekmeceli', 1930, 2470, 40, '2019-09-21', 16)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Delta DCF 466 D/S A+ Soğutucu/Dondurucu Tipi', 1360, 1870, 40, '2019-09-21', 16)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Simfer (+) FS5210 A+ 210 lt 5 Çekmeceli', 910, 1200, 40, '2019-09-21', 16)
insert into Products (proName, prePrice, salePrice, quantity, addDate, cateID) values ('Miele KF 37122 iD A++ 224 lt', 6360, 7800, 40, '2019-09-21', 16)

--************************************************


--update Employees set email = 'cekuban@store.com' where eUserName = 3

--select * from Employees
--drop table Employees