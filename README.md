
AutoStocker.API (Presentation Layer)

	Kullan�c�dan gelen HTTP isteklerini kar��lar.
	Swagger, Rate Limiting, CSRF korumas�, XSS �nlemleri gibi API g�venlik yap�land�rmalar� buradad�r.

AutoStocker.Application (Service Layer / �� Ak���)

	�� mant��� ve i� ak��lar�n� i�erir.
	Servisler, DTO'lar ve i� kurallar� burada bulunur.

AutoStocker.Domain (Core Business Layer)

	Entity, ValueObject, Enum ve Interface tan�mlamalar� burada yer al�r.
	Sistemin kurallar�n� tan�mlayan ana yap�.

AutoStocker.Infrastructure (Persistence & API Client Layer)

	Veritaban� ba�lant�s�, d�� API eri�imi, caching gibi teknik detaylar burada.
	EF Core, InMemory, veya dosya tabanl� veri eri�imleri buraya yaz�l�r.
	Fake Store API gibi d�� kaynaklara ula�an servislerin implemantasyonlar� burada.

