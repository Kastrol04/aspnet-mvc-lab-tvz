$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
$input_text = $input | Out-String
$log_entry = "[$timestamp] UX Agent Spawned`n$input_text`n---`n"
Add-Content -Path "$PSScriptRoot/agent_log.txt" -Value $log_entry
