using NWaves.Audio;
using NWaves.FeatureExtractors;
using NWaves.FeatureExtractors.Multi;
using NWaves.Transforms;

namespace DotNetMusicLooper.Library;

public class Analysis
{
    public void AnalyzeAudio(string filePath)
    {
        using var fs = File.OpenRead(filePath);
        var wave = new WaveFile(fs);

        var signal = wave.Signals[0];

        var stft = new Stft();
        var fft = new RealFft(1024);
        var mpeg7Extractor = new Mpeg7SpectralFeaturesExtractor(new()
        {
            FeatureList = "loudness",
            SamplingRate = wave.WaveFmt.SamplingRate,
        });

        var chromaExtractor = new ChromaExtractor(new()
        {
            SamplingRate = wave.WaveFmt.SamplingRate,
        });

        //var s_stft = stft.Direct(signal);
        //var s_power = stft.Spectrogram(signal).Select(x => x);
        var s_chroma = chromaExtractor.ComputeFrom(signal);
        var s_power_db = mpeg7Extractor.ComputeFrom(signal);

        /*
            S = librosa.core.stft(y=mlaudio.audio)
            S_power = np.abs(S) ** 2
            S_weighed = librosa.core.perceptual_weighting(
                S=S_power, frequencies=librosa.fft_frequencies(sr=mlaudio.rate)
            )
            mel_spectrogram = librosa.feature.melspectrogram(
                S=S_weighed, sr=mlaudio.rate, n_mels=128, fmax=8000
            )
            chroma = librosa.feature.chroma_stft(S=S_power)
            power_db = librosa.power_to_db(S_weighed, ref=np.median)
         */
    }
}
