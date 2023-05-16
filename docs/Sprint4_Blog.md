# Zielerreichung
Zu Beginn des Projektes wurden diverse Ziele definiert, welche für einen erfolgreichen Abschluss des Projektes erfüllt werden müssen. Diese sind im Dokument [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx) detailliert beschrieben.
Untenstehend sind diese nochmals Aufgeführt. Zusätzlich ist mittels der Checkbox angegeben ob das Ziel Abgeschlossen ist oder nicht:
- [x] Pflicht-Module und deren Erfüllungsgrad müssen ersichtlich sein
- [x] Diverse Module werden in unterschiedlichen Durchführungszeiträumen durchgeführt. Dieser Zeitraum muss für jedes Modul ersichtlich sein.
- [x] Übersicht: Es gibt ein Dashboard, auf welchem auf den ersten Blick alle Informationen zum Erfüllungsgrad des Studiums aufgeführt ist.
- [x] Planung: Jeder Anwender soll sein Studium individuell planen und eintragen können

Zusätzlich wurden noch ein weiteres Ziel betreffend der Code Qualität hinzugefügt:
- [ ] Im Frontend enhält jede Komponente und jede Klasse inkl. dernen Methoden (ausgenommen OnInit()) welche zusätzlich erstellt wurden einen Kommentar über deren Verwendungszweck.
- [x] Im .net Backend ist jede REST Schnittstelle, jeder Service und Erweiterungsklassen und Methoden im Code dokumentiert. 

## Stellungsnahme
Auf den ersten Blick sind aktuell fast alle Ziele bereits erreicht. Nur noch offen ist die Code Dokumenation im Frontend, welche noch nicht ganz zufriedenstellend ist. Ansonsten sind wir sehr zufrieden mit dem Ergebnis unserer Appliakation. Die Applikation ist einfach zu bedienen und ist viel besser herausgekommen als erwartet. Daher sind wir zuversichtlich das auch noch das letzte Ziel vor dem Final Pitch abgeschlossen werden kann.

# Vorgenommene Anpassungen
Bereits im ersten Sprint mussten wir unsere Vision ein bisschen eingrenzen. In diesem Kaptiel wurde beschrieben was und warum einige Funktionalitäten eingeschränkt werden mussten.

Dennoch können wir stolz sagen dass wir während der Sprints keine Features einschränken oder sogar verwerfen mussten. Wir konnten unsere geplanten Arbeiten wie gewünscht umsetzten!

## Registrierungsseite
"Es wird keine Registrierungsseite geben, es gibt lediglich hinterlegte Benutzer, welche sich einloggen können" - [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx).

Bereits vor dem Start der Realisierung haben wir als Team entschieden dass wir keine Registrierung umsetzen aufgrund der komplexität. Im nachhinein müssen wir zugeben das dieses Feature wohl trotzdem im Rahmen der Arbeit machbar gewesen wäre, da eigentlich im Backend nur einen API Call hinzugefügt werden musste und im Frontend nur eine Component. Dort haben wir uns wohl zu früh zu viel eingeschränkt.

## Studiengänge und Hochschulen
"In der umgesetzten Lösung wird nur der Studiengang «Bachelor of Science in Business Information Technology» der Berner Fachhochschule unterstützt werden." - [Sprint1.docx](https://gitlab.ti.bfh.ch/dsl-student-projects/wseg-23-fs/4p-sansibar/-/blob/main/docs/Sprint1.docx).
Weiter wurde unsere Vision auch nicht verfolgt, Studiengänge von anderen Schulen anzubieten.

Auch hier haben wir vor der Realisierung entschieden, dass standardmässig keine Studiengänge inkl. deren Modulen erfasst werden können. Diese sind direkt auf der Datenbank abgelegt. Dies wurde aufgrund des Zeitaufwandes so entschieden. Diese Entscheidung hat sich als passend erwiesen, da so viele weitere Komonenten wie auch API Schnittstellen nötig gewesen wären, was den Rahmen des Projektes einddeutig gesprängt hätte.

# Arbeitsaufteilung
In diesem Kapitel ist niedergeschrieben, wer bis jetzt welche Tätigkeiten übernommen hat. Dies kann sich im Verlauf des Projektes natürlich noch ändern.

| Aufgabe                                     | Verantwortlich                        |
| ------------------------------------------- | ------------------------------------- |
| Präsentation                                | Lars / Niels                          |
| Entwicklung Frontend                        | Lars / Roman                          |
| Entwicklung Backend                         | Lars / Roman                          |
| Datenmodell                                 | Lars / Roman                          |
| Nutzeranalyse                               | Mikael / Janik / Niels                |
| Problemanalyse / Erfassen der Anforderungen | Mikael / Janik / Niels                |
| Analyse Ist-Zustand                         | Mikael / Janik / Niels                |
| Organisation der Arbeiten                   | Mikael / Janik / Niels / Lars / Roman |
|                                             |                                       |

Während der Sprint gab es oft nur kurze Wartezeiten. Unsere Gruppe teilte sich die Arbeit Modulübergreifend auf, sodass die Verantwortungen über die verschiedenen Module in diesem Semster aufgeteilt sind. So konnten wir unsere Stärken optimal ausspielen.

Durch die Arbeitsaufteilung arbeiteten nur selten mehr als 2-3 Personen direkt für dieses Modul. So konnen Überschneidungen und Wartezeiten minimiert werden. Teilweise musste für die Sprint Reviews Content noch spontan angepasst werden, da noch ein Feature kurzfristig fertiggestellt wurde.

# Lessons Learned
Dieses Modul basiert auf einer erfolgreichen Teamzusammenarbeit. Alles in allem können wir voraussichtlich alle unsere Ziele für die Applikation erreichen. Dennoch haben wir einige Dinge welche wir das nächste Mal anders machen würden. Diese sind in diesem Kapitel aufgeführt.

## Technologieauswahl
Wir haben uns als Gruppe entschieden im Backend nicht aus Strapi sondern auf eine .Net Web API zu setzten. Dies aus dem Grund das Lars bereits mehrjährige Erfahrungen im .Net umfeld sammeln konnte. Daher war auch er im Lead für die Entwicklung der API.

So hatten wir den Vorteil dass wir eine API genau nach unseren Wünschen und Anforderungen entwickeln können. Diese erleichtere uns das Handling mit den Daten und der Businesslogik um ein vielfaches.

Dennoch würden wir beim nächsten Mal auf die empfohlenen Technologien setzen, denn uns wurde erst bei der Realisierung klar wurde, dass wir einen viel grösseren Mehraufwand betreiben müssen. Denn gemäss Aufgabestellung müssen wir lediglich ein Frontent & eine Stapi Api erstellen und konnfigurieren. Stattdessen haben wir zwei verschiedene Systeme welche geplant und entwickelt werden mussten. Zudem musste noch eine Datenbank geplant und erstellt werden, damit die Daten effizient und konsistent abgespeichert werden können. 

Dennoch haben wir die Entwicklung im Erfolgreich gemeistert. Dies ist jeodch ein wichtiges Learning für kommende Projekte.

## Adaptierung der Erwartungen
Zu Beginn waren wir sehr euphorisch, dass wir eine neue innovative Applikation realisieren können, mit welcher wir unser Studium einfach und effiziert planen und überwachen können. Nachdem uns jedoch klar wurde was für einen Aufwand damit verbunden war, merkten wir schnell dass wir dies nicht alles neben allen anderen Modulen einfach so realisieren konnten. Wir wurden auf den Boden der Tatsachen zurückgeholt.

Unser Learing: Zum Beginn nicht in einen Tunnelblick verfallen, sondern auch andere Einflussfaktoren wie Aufwände in anderen Modulen, Arbeiten vom Betrieb aus, etc. müssen bei der Planung von praktischen Projekten einberechnet werden. Ansonsten dort auf Berg von Arbeit welcher nur schwer beweltigt werden kann.
Dennoch sind wir uns auch für Zukunft sicher dass wir uns ambitieuse Ziele setzen wollen, damit auch in Zukunft spannende und innovative Projekte entstehen.