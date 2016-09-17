using System;

namespace Neas.Drivers
{
    /// <summary>
    /// Interface for different camera devices. Instead of returning the raw image the
    /// API is intended to detect patterns and invoke callbacks when it did.
    /// </summary>
    public interface ICameraDriver
    {
        /// <summary>
        /// Start looking for a pattern and raise the <see cref="ICameraDriver.Detected"/> event
        /// when it was detected.
        /// </summary>
        void Detect(Pattern pattern);

        /// <summary>
        /// Start looking for a pattern and invoke the callback when it was detected
        /// </summary>
        void Detect(Pattern pattern, Action successCallback);

        /// <summary>
        /// Start looking for a pattern and invoke the callback when it was detected
        /// </summary>
        void Detect(Pattern pattern, Action<Pattern> successCallback);

        /// <summary>
        /// Event raised when a pattern was detected
        /// </summary>
        event EventHandler<PatternDetectedEventArgs> Detected;
    }

    /// <summary>
    /// Base class for patterns to look for
    /// </summary>
    public abstract class Pattern
    {
    }

    /// <summary>
    /// Event agrs, when a pattern was detected
    /// </summary>
    public class PatternDetectedEventArgs : EventArgs
    {
        /// <summary>
        /// Initialize event args with the pattern that was detected.
        /// </summary>
        public PatternDetectedEventArgs(Pattern detectedPattern)
        {
            DetectedPattern = detectedPattern;
        }

        /// <summary>
        /// Pattern that was detected.
        /// </summary>
        public Pattern DetectedPattern { get; private set; }
    }
}

