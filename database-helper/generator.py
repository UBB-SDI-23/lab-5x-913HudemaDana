import csv
import random
from enum import Enum
from faker import Faker
from multiprocessing import Process

fake = Faker()

ALBUMS_COUNT = 1_000_000
ARTISTS_COUNT = 1_000_000
SHOPS_COUNT = 1_000_000
VINYLS_COUNT = 1_000_000
STOCKS_COUNT = 10_000_000

NATIONALITY = ["American", "Australian", "British", "Canadian", "Chinese", "French",
               "German", "Indian", "Italian", "Japanese", "Mexican", "Russian", "Spanish"]
NAME = ["Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Henry", "Isabel", "Jack", "Kate", "Lucas", "Maggie",
        "Nora", "Oliver", "Patty", "Quincy", "Rachel", "Samuel", "Tina", "Ursula", "Victor", "Wendy", "Xander", "Yara", "Zack"]
DESCRIPTION = [
    "An experimental electronic artist known for pushing the boundaries of sound.",
    "A soulful singer-songwriter with a knack for poignant lyrics.",
    "A rapper with a sharp tongue and witty wordplay.",
    "A rock band with a heavy sound and a penchant for catchy hooks.",
    "A jazz pianist with a virtuosic touch and a penchant for improvisation.",
    "An indie folk artist with a tender voice and intimate songwriting style.",
    "A metal band known for their ferocious energy and crushing riffs.",
    "A country singer with a heart of gold and a voice to match.",
    "A pop singer with a gift for melody and a flair for the dramatic.",
    "A classical composer whose works are celebrated for their beauty and complexity.",
]

LYRICS = [
    "I'm walking on sunshine, whoa-oh",
    "Somebody once told me the world is gonna roll me",
    "It's a beautiful day, don't let it get away",
    "Cause baby you're a firework",
    "Someday, I wish upon a star",
    "I believe I can fly",
    "I've got the eye of the tiger",
    "I will always love you",
    "What doesn't kill you makes you stronger",
    "You're a sky full of stars",
    "Ain't no mountain high enough",
    "We're soaring, flying",
    "I'm blue da ba dee da ba die",
    "Don't stop believin'",
    "I will survive",
    "We are the champions, my friends",
    "Sweet dreams are made of this",
    "I'm in love with the shape of you",
    "The rhythm is gonna get you",
    "I want it that way"
]
TOWN = ['New York', 'Los Angeles', 'Chicago', 'Houston', 'Phoenix', 'Philadelphia', 'San Antonio',
        'San Diego', 'Dallas', 'San Jose', 'Austin', 'Jacksonville', 'Fort Worth', 'Columbus', 'San Francisco', 'Charlotte', 'Indianapolis', 'Seattle', 'Denver', 'Washington', 'Boston', 'Nashville', 'El Paso', 'Detroit', 'Memphis', 'Portland', 'Oklahoma City', 'Las Vegas', 'Louisville', 'Baltimore', 'Milwaukee', 'Albuquerque', 'Tucson', 'Fresno', 'Mesa', 'Sacramento', 'Atlanta', 'Kansas City', 'Colorado Springs', 'Miami', 'Raleigh', 'Omaha', 'Long Beach', 'Virginia Beach', 'Oakland', 'Minneapolis', 'Tulsa', 'Wichita', 'New Orleans']
EDITION = ["Limited edition", "Collector's edition",
           "Deluxe edition", "Standard edition", "Reissue edition"]
MATERIAL = ["180-gram vinyl", "Colored vinyl", "Picture disc", "Clear vinyl"]
GROOVE = ["Microgroove", "Monaural", "Stereo"]
SPEED = ["33 1/3 RPM", "45 RPM", "78 RPM"]
CONDITION = ["Mint", "Near Mint", "Very Good Plus",
             "Very Good", "Good", "Fair", "Poor"]


def create_albums_csv():
    print("Begin create_albums_csv")

    with open("albums.csv", "w", newline="") as f:
        writer = csv.writer(f)

        for i in range(1, ALBUMS_COUNT + 1):
            name = random.choice(NAME)
            lyrics = random.choice(LYRICS)
            realise_date = fake.date_between(
                start_date="-10y", end_date="today")
            artist_id = random.randint(1, ARTISTS_COUNT)

            writer.writerow([i, name, lyrics, realise_date, artist_id])

    print("End create_albums_csv")


def create_artists_csv():
    print("Begin create_artists_csv")

    with open("artists.csv", "w", newline="") as f:
        writer = csv.writer(f)

        for i in range(1, ARTISTS_COUNT + 1):
            first_name = fake.first_name()
            last_name = fake.last_name()
            age = random.randint(10, 100)
            nationality = random.choice(NATIONALITY)
            active_years = random.randint(1, 50)

            num_descriptions = random.randint(1, len(DESCRIPTION))
            chosen_descriptions = random.sample(DESCRIPTION, num_descriptions)

            description = ", ".join(chosen_descriptions)

            writer.writerow([i, first_name, last_name, age,
                            nationality, active_years, description])

    print("End create_artists_csv")


def create_shops_csv():
    print("Begin create_shops_csv")

    with open("shops.csv", "w", newline="") as f:
        writer = csv.writer(f)

        for i in range(1, SHOPS_COUNT + 1):
            town = random.choice(TOWN)
            address = fake.address()

            writer.writerow([i, town, address])

    print("End create_shops_csv")


def create_vinyls_csv():
    print("Begin create_vinyls_csv")

    with open("vinyls.csv", "w", newline="") as f:
        writer = csv.writer(f)

        for i in range(1, VINYLS_COUNT + 1):
            edition = random.choice(EDITION)
            durability = random.randint(3, 10)
            size = random.randint(10, 16)
            material = random.choice(MATERIAL)
            groove = random.choice(GROOVE)
            speed = random.choice(SPEED)
            condition = random.choice(CONDITION)
            album_id = random.randint(1, ALBUMS_COUNT)

            writer.writerow([i, edition, durability, size,
                            material, groove, speed, condition, album_id])

    print("End create_vinyls_csv")


def create_stocks_csv():
    print("Begin create_stocks_csv")

    unique_stocks = set()
    for _ in range(STOCKS_COUNT):
        while True:
            shop_id = random.randint(1, SHOPS_COUNT)
            vinyl_id = random.randint(1, VINYLS_COUNT)
            if (shop_id, vinyl_id) not in unique_stocks:
                unique_stocks.add((shop_id, vinyl_id))
                break

    print(f"Generated {len(unique_stocks)} unique stocks. Writing...")

    with open("stocks.csv", "w", newline="") as f:
        writer = csv.writer(f)

        current = 0
        for shop_id, vinyl_id in unique_stocks:
            available_vinyls = random.randint(10, 500)
            price = random.randint(10, 200)
            writer.writerow(
                [current+1, shop_id, vinyl_id, available_vinyls, price])

            current += 1
            if current % 1000000 == 0:
                print(f"Processed {current} stocks")

    print("End create_stocks_csv")


if __name__ == "__main__":
    processes = []
    for func in [
        create_artists_csv,
        create_albums_csv,
        create_shops_csv,
        create_vinyls_csv,
        create_stocks_csv,
    ]:
        p = Process(target=func)
        processes.append(p)
        p.start()

    for p in processes:
        p.join()

    print("\nFinished generating data")
