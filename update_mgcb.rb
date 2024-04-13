#!/usr/bin/env ruby

audio_dir = '/media/yazu/DarkWoods/darkwoods_game/Audio'
mgcb_file = '/media/yazu/DarkWoods/darkwoods_game/Content.mgcb'

File.open(mgcb_file, 'w') do |file|
  file.puts "#----------------------------- Global Properties -----------------------------"
  file.puts "/outputDir:net8.0/Database"
  file.puts "/intermediateDir:obj"
  file.puts "/platform:Windows"
  file.puts "/config:"
  file.puts "/profile:Reach"
  file.puts "/compress:False"
  file.puts ""
  file.puts "#-------------------------------- References --------------------------------"
  file.puts ""
  file.puts "#---------------------------------- Content ---------------------------------"

  Dir.glob("#{audio_dir}/*.ogg").each do |wav_file|
    file.puts "# Audio Content"
    file.puts "/importer:OggImporter"
    file.puts "/processor:SongProcessor"
    file.puts "/build:Audio/#{File.basename(wav_file)}"
  end
end

