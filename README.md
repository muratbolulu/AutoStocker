
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

