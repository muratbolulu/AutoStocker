AutoStocker.API (Presentation Layer)

	Kullanýcýdan gelen HTTP isteklerini karþýlar.
	Controller'lar burada yer alýr.
	Swagger, Rate Limiting, CSRF korumasý, XSS önlemleri gibi API güvenlik yapýlandýrmalarý buradadýr.

AutoStocker.Application (Service Layer / Ýþ Akýþý)

	Ýþ mantýðý ve iþ akýþlarýný içerir.
	Servisler, DTO'lar (Data Transfer Objects) ve iþ kurallarý burada bulunur.
	Veri eriþim katmanýna (AutoStocker.Data) baðýmlýdýr.

AutoStocker.Domain (Core Business Layer)

	Entity, ValueObject, Enum ve Interface tanýmlamalarý burada yer alýr.
	Sistemin kurallarýný tanýmlayan ana yapý.

AutoStocker.Infrastructure (Persistence & API Client Layer)

	Veritabaný baðlantýsý, dýþ API eriþimi, caching gibi teknik detaylar burada.
	EF Core, InMemory, veya dosya tabanlý veri eriþimleri buraya yazýlýr.
	Fake Store API gibi dýþ kaynaklara ulaþan servislerin implemantasyonlarý burada.


SOLID ve Clean Architecture'da Yeri
	Katman			Görev
	Domain			Arayüz (interface) tanýmlar – ne yapýlacaðýný söyler.
	Infrastructure	Arayüzü uygular – nasýl yapýlacaðýný gösterir.
	Application		Ýþ mantýðýný uygular – ne zaman yapýlacaðýný belirler.







Notlar:

	Fake Store API da, eþieltirme için productCode alaný yoktur.(pdf te aksi belirtilmektedir.