
AutoStocker.API (Presentation Layer)

	Kullanýcýdan gelen HTTP isteklerini karþýlar.
	Swagger, Rate Limiting, CSRF korumasý, XSS önlemleri gibi API güvenlik yapýlandýrmalarý buradadýr.

AutoStocker.Application (Service Layer / Ýþ Akýþý)

	Ýþ mantýðý ve iþ akýþlarýný içerir.
	Servisler, DTO'lar ve iþ kurallarý burada bulunur.

AutoStocker.Domain (Core Business Layer)

	Entity, ValueObject, Enum ve Interface tanýmlamalarý burada yer alýr.
	Sistemin kurallarýný tanýmlayan ana yapý.

AutoStocker.Infrastructure (Persistence & API Client Layer)

	Veritabaný baðlantýsý, dýþ API eriþimi, caching gibi teknik detaylar burada.
	EF Core, InMemory, veya dosya tabanlý veri eriþimleri buraya yazýlýr.
	Fake Store API gibi dýþ kaynaklara ulaþan servislerin implemantasyonlarý burada.



ExceptionHandler
	API'de oluþabilecek hatalarý merkezi olarak yakalar ve uygun HTTP cevaplarýný döner.
	ExceptionHandlingMiddleware ile pipeline'a eklendi. 
	Kullaným örneði: Product/GetCsrfToken 'da ArgumentNullException ile yapýldý.



Proje açýklamasý ve nasýl çalýþtýðý:
	Api,
		Kullanýcýdan gelen istekleri alýr ve Application katmanýndaki servisleri çaðýrýr.
	Application katmaný,
		Domain Katmanýndaki repository arayüzleri (IProductRepository, IOrderRepository) ile veri katmanýna eriþir.
	Domain katmaný
		Diðer katmanlarý tanýmaz, eriþemez.Buy katmanda implementasyon yoktur, sadece interface tanýmlamalarý bulunur.
	Infrastructure 
		InMemoryProductRepository, InMemoryOrderRepository gibi repository implementasyonlarý içerir
		Dýþ servisleri soyutlayan interface’leri (IFakeStoreClient) kullanýr. FakeStoreClient ile dýþ API'den ürün verisi çeker.

	
